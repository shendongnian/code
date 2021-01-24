    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace Dicerolling
    {
        class Program
        {
            static void Main(string[] args)
            {
                
                Random x = new Random();
                int throw_times = 1;
                int sum = 0;
                int[] dice = new int[2];
                dice[0] = x.Next(1, 7);
                dice[1] = x.Next(1, 7);
                Console.WriteLine("enter the no of rollings :");
                var n = int.Parse(Console.ReadLine());
                for (int i = 1; i <= n; i++)
                {
                    dice[0] = x.Next(1, 7);
                    dice[1] = x.Next(1, 7);
                    int total_var = dice[0] + dice[1];
                    sum +=  dice[0] + dice[1] ;//total in array
                    Console.Write("Throw " + throw_times + ": " + dice[0] + " d " + dice[1] + " = ");
                    Console.WriteLine(total_var);
                    throw_times++;
                    Array.Sort(dice);
                    for (int a = dice.Length - 1; a >= 0; a--)
                    {
                        int s = dice[a];
                        Console.WriteLine("#" + s);
                    }
                }
                Console.WriteLine("Total sum: " + sum);//only returns sum of last 2 rolls
               
                Console.ReadLine();
            }
        }
    }
