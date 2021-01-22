    using System;
    using System.Linq;
    
    public class Test
    {
        static void Main()
        {
            var items = new string[] { "the", "quick", "brown", "fox", 
                    "jumps", "over", "the", "lazy", "dog" };
            
            var query = items.OrderBy(x => !x.Contains("o"))
                             .ThenBy(x => x);
            
            foreach (string word in query)
            {
                Console.WriteLine(word);
            }
        }
    }
