        using System.Linq;
        static void Main(string[] args)
        {
            int[] test = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            var t = test.AsQueryable().Skip(5).Take(5);
            foreach (int i in t)
            {
                Console.WriteLine(i.ToString());
            }
            Console.ReadLine();
        }
