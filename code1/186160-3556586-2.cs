    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using DoubleProjectTwo;  //<----- to use ClassB in the main
    
    namespace DoubleProject
    {
        class Program
        {
            static void Main(string[] args)
            {
                ClassB foo = new ClassB();
    
                Console.WriteLine(foo.textB);
                Console.ReadLine();
            }
        }
    }
