using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoContatos
{
    internal class Program
    {
        //Aluno: Fernando Oliveira Sampaio
        static List<(string nome, string telefone)> contatos = new List<(string nome, string telefone)>();


        static void adicionarContato()
        {
            int op;
            do
            {
                Console.Clear();

                Console.WriteLine("--- ADICIONAR CONTATOS ---");

                Console.Write("\nDigite o nome do contato: ");
                string nome = Console.ReadLine();

                Console.Write("Digite o número de telefone: ");
                string telefone = Console.ReadLine();

                contatos.Add((nome, telefone));

                Console.WriteLine($"\nContato {nome} adicionado com sucesso!\n");

                Console.WriteLine("Deseja continuar cadastrando? 1 -> SIM... 0 -> NÃO...");
                op = Convert.ToInt32(Console.ReadLine());

                  
            } while (op != 0);

            Console.WriteLine("\nPressione para visualizar o Menu...");
            Console.ReadKey();

        }

        static void buscarContato()
        {
            int excluir;

            Console.Write("Digite o nome do contato: ");
            string nome = Console.ReadLine();
            nome.ToUpper(); // para ficar mais fácil de identificar o nome 

            List <(string nome, string telefone)> consultNomes = contatos.Where(n => n.nome.Contains(nome)).ToList();

            if (consultNomes.Any())
            {

                for (int i = 0; i < consultNomes.Count; i++)
                {
                    Console.WriteLine($" {i + 1}. Nome: {consultNomes[i].nome}\n Nº: {consultNomes[i].telefone}\n");
                }

                Console.WriteLine("Deseja excluir contato? 1 -> SIM... 0 -> NÃO...");
                excluir = Convert.ToInt32(Console.ReadLine());

                if (excluir == 1)
                {
                    for (int i = 0; i < consultNomes.Count; i++)
                    {
                        contatos.Remove(consultNomes[i]);
                        Console.WriteLine($"\nContato {i + 1} removido com sucesso!");
                    }
                }
            }
            else
            {
                Console.WriteLine("Nenhum contato encontrado!");
            }


            Console.WriteLine("\nPressione para visualizar o Menu...");
            Console.ReadKey();
        }

        static void listaContatos()
        { 
            contatos = contatos.OrderBy(p => p.nome).ToList();
            for(int i = 0; i < contatos.Count; i++)
            {
                Console.WriteLine($"Nome: {contatos[i].nome}  \nTelefone: {contatos[i].telefone}\n");

            }
            Console.WriteLine("\nPressione para visualizar o Menu...");
            Console.ReadKey();

        }

        static void Main(string[] args)
        {
            int opcao;

            do
            {
                Console.Clear();

                Console.WriteLine("--- GERENCIAMENTO DE CONTATOS ---\n");
                Console.WriteLine("|Digite [1] para Adicionar Novo Contato      |");
                Console.WriteLine("|Digite [2] para Buscar Contato              |");
                Console.WriteLine("|Digite [3] para Visualizar todos os Contatos|");
                Console.WriteLine("|Digite [0] para Sair...                     |");
                opcao = Convert.ToInt32(Console.ReadLine());

                switch (opcao) 
                {
                    case 1:
                        {
                            Console.Clear();
                            adicionarContato();  

                        break;
                        }
                    case 2:
                        {
                            Console.Clear();

                            Console.WriteLine("--- BUSCAR DE CONTATOS ---\n");
                            buscarContato();

                            break;
                        }
                    case 3:
                        {
                            Console.Clear();

                            Console.WriteLine("--- LISTA DE CONTATOS ---\n");
                            listaContatos();

                            break;
                        }
                    case 0:
                        {
                            Console.WriteLine("\nObrigado pela interação!!");
                            Console.ReadKey();

                            break;
                        }                              
                }
            } while (opcao != 0);
        }
    }
}
