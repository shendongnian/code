    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApp1
    {
        class Program
        {
            static IEnumerable<string> Split(string text, char splitChar)
            {
                StringBuilder between = new StringBuilder();
    
                bool inside = false;
    
                foreach (char c in text)
                {
                    if (c == splitChar && !inside)
                    {
                        between.Clear();
                        inside = true;
                        continue;
                    }
    
                    if (c == splitChar && inside && between.Length != 0)
                    {
                        yield return between.ToString();
    
                        inside = false;
                        continue;
                    }
    
                    between.Append(c);
                }
            }
    
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
        }
    }
