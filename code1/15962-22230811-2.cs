    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    class ReverseDictionaryLookupDemo
    {
        static void Main()
        {
            var dict = new Dictionary<int, string>();
            dict.Add(4, "Four");
            dict.Add(5, "Five");
            dict.Add(1, "One");
            dict.Add(11, "One"); // duplicate!
            dict.Add(3, "Three");
            dict.Add(2, "Two");
            dict.Add(44, "Four"); // duplicate!
    
            Console.WriteLine("\n== Enumerating Distinct Values ==");
            foreach (string value in dict.Values.Distinct())
            {
                string valueString =
                    String.Join(", ", GetKeysFromValue(dict, value));
    
                Console.WriteLine("{0} => [{1}]", value, valueString);
            }
        }
    
        static List<int> GetKeysFromValue(Dictionary<int, string> dict, string value)
        {
            // Use LINQ to do a reverse dictionary lookup.
            // Returns a 'List<T>' to account for the possibility
            // of duplicate values.
            return
                (from item in dict
                 where item.Value.Equals(value)
                 select item.Key).ToList();
        }
    }
