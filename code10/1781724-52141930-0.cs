    using System;
    using System.Linq;
    using System.Collections.Generic;
    
    namespace Whatever
    {
        class Program
        {
            static void Main(string[] args)
            {
                var vowels = new Dictionary<string, int>(5, StringComparer.OrdinalIgnoreCase) { { "a", 1 }, { "e", 5 }, { "i", 9 }, { "o", 15 }, { "u", 21 } };
    
                Console.WriteLine("Write something : ");
                var input = Console.ReadLine();
    
                var sum = input.Select((value, index) => new { value, index })
                    .Sum(x =>
                        {
                            vowels.TryGetValue(x.value.ToString(), out var multiplier);
                            return (x.index + 1) * multiplier;
                        });
    
                Console.ReadLine();
            }
        }
    }
