    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    class Test
    {
        static void Main()
        {
            var list = new List<string> { 
                "banana", "apple", "lemon", "orange", 
                "cherry", "pear", "яблоко", "лимон",
                "груша", "банан", "апельсин", "вишня",
                "appleвишня", "вишняapple"
            };
            var result = list.OrderBy(GetFirstCyrillicIndex).ThenBy(x => x).ToList();
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    
        private static int GetFirstCyrillicIndex(string text)
        {
            // This could be written using LINQ, but it's probably simpler this way.
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] >= 0x400 && text[i] <= 0x4ff)
                {
                    return i;
                }
            }
            return int.MaxValue;
        }
    }
