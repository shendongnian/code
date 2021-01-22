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
                List<LOL> list = new List<LOL>();
                list.Add(new LOL());
                list.Add(new LOL());
    
                IEnumerable<LOL> filter = list.Where(
                    delegate(LOL lol)
                    {
                        return lol.yes();
                    }
                );
    
                // Breakpoint #2 will not have been yet.
                Console.Write("No Breakpoint"); // Breakpoint #1 
                // (Breakpoint #2 will now be hit.)
                Console.Write("Breakpoint! " + filter.Count()); 
            }
    
            class LOL
            {
                public bool yes()
                {
                    bool ret = true; // Breakpoint #2
                    return ret;
                }
    
            }
    
        }
    }
