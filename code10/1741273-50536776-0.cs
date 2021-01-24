    using System;
    using System.Collections.Generic;
    
    namespace StringToInt
    {
        class Program
        {
            static void Main(string[] args)
            {
                String[] path = { "1", "2", "3", "a", "b7" };
                List<int> numb = new List<int>();
    
                
                foreach (string p in path)
                {
                    if (int.TryParse(p, out int result))
                    {
                        numb.Add(result);
                    }
                }
    
                for (int i = 0; i < path.Length; i++)
                {
                    Console.WriteLine(path[i]);
                }
    
                for (int i = 0; i < numb.Count; i++)
                {
                    Console.WriteLine(numb[i]);
                }
            }
        }
    }
