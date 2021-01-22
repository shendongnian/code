    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                DateTime dtEnd = DateTime.Now.AddSeconds(1.0);
                int i = 0;
                while (DateTime.Now < dtEnd)
                {
                    i++;
                    Thread.Sleep(1);
                }
    
                Console.WriteLine(i.ToString());
    
                i = 0;
                long lStart = DateTime.Now.Ticks;
                while (i++ < 1000)
                    Thread.Sleep(1);
    
                long lTmp = (DateTime.Now.Ticks - lStart) / 10000;
    
                Console.WriteLine(lTmp.ToString());
    
                Console.Read();
            }
        }
    }
