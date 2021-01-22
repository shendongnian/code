    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        public class Item
        {
            public int Weight { get; set; }
            public string Name { get; set; }
        }
        public static class Extensions
        {
            public static IEnumerable<T> Weighted<T>(this IEnumerable<T> list, Func<T, int> weight)
            {
                List<T> output = new List<T>();
                foreach (T t in list)
                {
                    int w = weight(t);
                    for (int i = 0; i < w; i++)
                        yield return t;
                }
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                List<Item> list = new List<Item>();
                list.Add(new Item { Name = "one", Weight = 5 });
                list.Add(new Item { Name = "two", Weight = 1 });
                Random rand = new Random(0);
                list = list.Weighted<Item>((x) => x.Weight).ToList();
                for (int i = 0; i < 20; i++)
                {
                    int index = rand.Next(list.Count());
                    Console.WriteLine(list.ElementAt(index).Name);
                }
                Console.ReadLine();
            }
        }
    }
