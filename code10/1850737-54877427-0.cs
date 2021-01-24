    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ArgWrite
    {
        class ArgWrite    {
            static void Main(string[] args)
            {
                for (int i = 0; i <= args.Length; i++)
                {
                    string arg = args[i];
                    Console.WriteLine("arg index: [{i}] argument is {arg} ");
                }
    
                Console.ReadKey();
            }
        }
    }
