    using System;
    using System.Collections.Generic;
    using System.Text;
    
    namespace Dllcaller
    {
        class Program
        {
            static void Main(string[] args)
            {
                Adder a = new Adder();
                Console.WriteLine(a.add(1, 7));
                while (true) ;
            }
        }
    }
