    using System;
    using System.Linq;
    class Program
    {
        static void Main(string[] args)
        {
            Program[] array = new Program[0];
            Program[] query = array.DefaultIfEmpty(new Program()).ToArray();
            foreach (var item in query)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadKey();
        }
    }
