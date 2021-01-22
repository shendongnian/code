    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                int iterations = 1000000;
                string val = "01234";
    
                Console.Write("Run 1: int.Parse() ");
                DateTime start = DateTime.Now;
                DoParse(iterations, val);
                TimeSpan duration = DateTime.Now - start;
                Console.WriteLine("Duration: " + duration.TotalMilliseconds.ToString() + "ms");
    
                Console.Write("Run 1: Convert.ToInt32() ");
                start = DateTime.Now;
                DoConvert(iterations, val);
                duration = DateTime.Now - start;
                Console.WriteLine("Duration: " + duration.TotalMilliseconds.ToString() + "ms");
    
                Console.Write("Run 2: int.Parse() ");
                start = DateTime.Now;
                DoParse(iterations, val);
                duration = DateTime.Now - start;
                Console.WriteLine("Duration: " + duration.TotalMilliseconds.ToString() + "ms");
    
                Console.Write("Run 2: Convert.ToInt32() ");
                start = DateTime.Now;
                DoConvert(iterations, val);
                duration = DateTime.Now - start;
                Console.WriteLine("Duration: " + duration.TotalMilliseconds.ToString() + "ms");
    
                Console.Write("Run 3: int.Parse() ");
                start = DateTime.Now;
                DoParse(iterations, val);
                duration = DateTime.Now - start;
                Console.WriteLine("Duration: " + duration.TotalMilliseconds.ToString() + "ms");
    
                Console.Write("Run 3: Convert.ToInt32() ");
                start = DateTime.Now;
                DoConvert(iterations, val);
                duration = DateTime.Now - start;
                Console.WriteLine("Duration: " + duration.TotalMilliseconds.ToString() + "ms");
    
                Console.ReadKey();
            }
    
            static void DoParse(int iterations, string val)
            {
                int x;
                for (int i = 0; i < iterations; i++)
                {
                    x = int.Parse(val);
                }
            }
    
            static void DoConvert(int iterations, string val)
            {
                int x;
                for (int i = 0; i < iterations; i++)
                {
                    x = Convert.ToInt32(val);
                }
            }
    
        }
    }
