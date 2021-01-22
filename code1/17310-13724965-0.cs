    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace consolePlay
    {
        class Program
        {
            static void Main(string[] args)
            {
                Program.test(new DateTime());
                Program.test(null);
                //Program.test(); // <<< Error.  
                // "No overload for method 'test' takes 0 arguments"  
                // So don't mistake nullable to be optional.
    
                Console.WriteLine("Done.  Return to quit");
                Console.Read();
            }
    
            static public void test(DateTime? dteIn)
            {
                Console.WriteLine("#" + dteIn.ToString() + "#");
            }
        }
    }
