    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Threading;
    
    namespace ConsoleApp6
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                int x = 10;
                Thread t1 =new Thread(new ParameterizedThreadStart(order1));
                t1.IsBackground = true;//i can stope 
                t1.Start(x);
    
                Thread t2=new Thread(order2);
                t2.Priority = ThreadPriority.Highest;
                t2.Start();
    
                Console.ReadKey();
            }//Main
    
            static void  order1(object args)
            {
                int x = (int)args;
    
                
                    for (int i = 0; i < x; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(i.ToString() + " ");
                }
            }
    
            static void order2()
            {
                for (int i = 100; i > 0; i--)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(i.ToString() + " ");
                }
            }`enter code here`
        }
    }
