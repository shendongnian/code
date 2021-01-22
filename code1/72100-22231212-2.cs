    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    class SortedDictionaryEnumerationDemo
    {
        static void Main()
        {
            var dict = new SortedDictionary<int, string>();
            dict.Add(4, "Four");
            dict.Add(5, "Five");
            dict.Add(1, "One");
            dict.Add(3, "Three");
            dict.Add(2, "Two");
    
            Console.WriteLine("== Enumerating Items ==");
            foreach (var item in dict)
            {
                Console.WriteLine("{0} => {1}", item.Key, item.Value);
            }
    
            Console.WriteLine("\n== Enumerating Keys ==");
            foreach (int key in dict.Keys)
            {
                Console.WriteLine("{0} => {1}", key, dict[key]);
            }
    
            Console.WriteLine("\n== Enumerating Values ==");
            foreach (string value in dict.Values)
            {
                Console.WriteLine("{0} => {1}", value, GetKeyFromValue(dict, value));
            }
        }
    
        static int GetKeyFromValue(SortedDictionary<int, string> dict, string value)
        {
            // Use LINQ to do a reverse dictionary lookup.
            try
            {
                return
                    (from item in dict
                     where item.Value.Equals(value)
                     select item.Key).First();
            }
            catch (InvalidOperationException e)
            {
                return -1;
            }
        }
    }
