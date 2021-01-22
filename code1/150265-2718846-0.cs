    using System;
    using System.Collections.Generic;
    class Program
    {
        static void Main(string[] args)
        {
            var data = new List<string> { "fname", "lname", "home", "home", "company" };
            foreach (var duplicate in FindDuplicates(data))
            {
                Console.WriteLine("Duplicate: {0} at index {1}", duplicate.Item1, duplicate.Item2);
            }
        }
        public static IEnumerable<Tuple<T, int>> FindDuplicates<T>(IEnumerable<T> data)
        {
            var hashSet = new HashSet<T>();
            int index = 0;
            foreach (var item in data)
            {
                if (hashSet.Contains(item))
                {
                    yield return Tuple.Create(item, index);
                }
                else
                {
                    hashSet.Add(item);
                }
                index++;
            }
        }
    }
