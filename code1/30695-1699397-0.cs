    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ClosureTest
    {
        class Program
        {   
            static void Main(string[] args)
            {
                string userFilter = "C";            
                IEnumerable<string> query = (from m in typeof(String).GetMethods()
                                             where m.Name.StartsWith(userFilter)
                                             select m.Name.ToString()).Distinct();
                
                while(userFilter.ToLower() != "q")
                {
                    DiplayStringMethods(query, userFilter);
                    userFilter = GetNewFilter();
                }
            }
    
            static void DiplayStringMethods(IEnumerable<string> methodNames, string userFilter)
            {
                Console.WriteLine("Here are all of the String methods starting with the letter \"{0}\":", userFilter);
                Console.WriteLine();
    
                foreach (string methodName in methodNames)
                    Console.WriteLine("  * {0}", methodName);
            }
    
            static string GetNewFilter()
            {
                Console.WriteLine();
                Console.Write("Enter a new starting letter (type \"Q\" to quit): ");
                ConsoleKeyInfo cki = Console.ReadKey();
                Console.WriteLine();
                return cki.Key.ToString();
            }
        }
    }
