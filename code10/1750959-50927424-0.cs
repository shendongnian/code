    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace Demo
    {
        public static class Program
        {
            public static void Main(string[] args)
            {
                var requiredOrder = new [] { "PH", "HH", "PR", "SR", "UN", "UD", "WD", "WE", "OT" };
                var listToBeSorted = new List<KeyValuePair<string, string>>() {
                    new KeyValuePair<string, string>("A", "PR"),
                    new KeyValuePair<string, string>("B", "PH"),
                    new KeyValuePair<string, string>("C", "HH"),
                    new KeyValuePair<string, string>("D", "WD"),
                    new KeyValuePair<string, string>("E", "OT"),
                    new KeyValuePair<string, string>("F", "UN"),
                    new KeyValuePair<string, string>("G", "UD"),
                    new KeyValuePair<string, string>("H", "WE"),
                    new KeyValuePair<string, string>("I", "SR")
                };
                int[] indices = Enumerable.Range(0, requiredOrder.Length).ToArray(); // (1)
                Array.Sort(requiredOrder, indices); // (2)
                foreach (var index in indices) // (3)
                {
                    Console.WriteLine(listToBeSorted[index].Key);
                }
            }
        }
    }
