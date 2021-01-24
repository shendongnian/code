        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        using System.Threading;
        using System.Threading.Tasks;
    
        namespace Practice
    {
        class Program
        {
            static bool write = true;
            static void Main(string[] args)
            {
                //Write the stars using a background thread
                new Thread(() =>
                {
                    Thread.CurrentThread.IsBackground = true;
                    WriteStars();
                }).Start();
    
                while (true)
                {
                    //Read the user input
                    var input = Console.ReadLine();
                    //Check the user input
                    if (input.Equals("stop", StringComparison.OrdinalIgnoreCase))
                    {
                        write = false;
                        Console.WriteLine("Finished. Program stopped!");
                        Console.ReadKey();
                        break;
                    }
                }
            }
    
            private static void WriteStars()
            {
                while (write)
                {
                    Console.Write("*");
    
                    //Make the thread wait for half a second
                    Thread.Sleep(500);
                }
            }
        }
    }
