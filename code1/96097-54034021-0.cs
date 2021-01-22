    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    namespace ConsoleApp4
    {
        class Program
        {
            public static int[] X = new int[30];
            static readonly object _object = new object();
            public static int count=0;
            public static void PutNumbers(int numbersS, int numbersE)
            {
                for (int i = numbersS; i < numbersE; i++)
                {
                    Monitor.Enter(_object);
                    try
                    {
                        if(count<30)
                        {
                            X[count] = i;
                            count++;
                            Console.WriteLine("Punt in " + count + "nd: "+i);
                            Monitor.Pulse(_object); 
                        }
                        else
                        {
                            Monitor.Wait(_object);
                        }
                    }
                    finally
                    {
                        Monitor.Exit(_object);
                    }
                }
            }
            public static void RemoveNumbers(int numbersS)
            {
                for (int i = 0; i < numbersS; i++)
                {
                    Monitor.Enter(_object);
                    try
                    {
                        if (count > 0)
                        {
                            X[count] = 0;
                            int x = count;
                            count--;
                            Console.WriteLine("Removed " + x + " element");
                            Monitor.Pulse(_object);
                        
                        }
                        else
                        {
                            Monitor.Wait(_object);
                        }
                    }
                    finally
                    {
                        Monitor.Exit(_object);
                    }
                }
            }
            static void Main(string[] args)
            {
                Thread W1 = new Thread(() => PutNumbers(10,50));
                Thread W2 = new Thread(() => PutNumbers(1, 10));
                Thread R1 = new Thread(() => RemoveNumbers(30));
                Thread R2 = new Thread(() => RemoveNumbers(20));
                W1.Start();
                R1.Start();
                W2.Start();
                R2.Start();
                W1.Join();
                R1.Join();
                W2.Join();
                R2.Join();
            }
        }
    }
