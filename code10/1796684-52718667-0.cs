    using System;
    using System.Collections.Generic;
    namespace Demo
    {
        static class Program
        {
            public static void Main()
            {
                var test = new SortedList<string, int>();
                test.Add("one", 1);
                test.Add("two", 2);
                test[test.Keys[test.Count - 1]] = 3;
                foreach (var item in test)
                {
                    Console.WriteLine($"test[{item.Key}] == {item.Value}");
                }
            }
        }
    }
