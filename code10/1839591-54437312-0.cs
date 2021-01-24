    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string text = "\"/tutorial/example/example-a/\" aaa \"/tutorial/example/example-b/\" bbb \"/tutorial1/example1/example-a/\"";
    
                string search = "example-A";
    
                Console.WriteLine("All results:");
                Console.WriteLine();
                foreach (string item in Split(text, '"'))
                {
                    Console.WriteLine(item);
                }
    
                Console.WriteLine();
                Console.WriteLine();
    
                Console.WriteLine($"Search results of '{search}' case-insensitive:");
                Console.WriteLine();
                foreach (string item in Split(text, '"').Where(i => i.IndexOf(search, StringComparison.OrdinalIgnoreCase) != -1))
                {
                    Console.WriteLine(item);
                }
    
                Console.ReadKey();
            }
    
            static IEnumerable<string> Split(string text, char splitChar)
            {
                StringBuilder between = new StringBuilder();
    
                bool inside = false;
    
                foreach (char c in text)
                {
                    if (inside && between.Length != 0 && c == splitChar)
                    {
                        yield return between.ToString();
    
                        inside = false;
                        continue;
                    }
    
                    if (!inside && c == splitChar)
                    {
                        between.Clear();
                        inside = true;
                        continue;
                    }
    
                    between.Append(c);
                }
            } 
        }
    }
    
