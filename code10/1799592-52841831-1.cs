    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random(DateTime.Now.Millisecond);
            var values = new List<int>();
            for (int i = 0; i < 100; i++)
            {
                values.Add(random.Next(-1000, 1000));
            }
            foreach (var item in values.OrderBy(i => Math.Abs(i)))
            {
                Console.WriteLine($"{item}, ");
            }
            Console.WriteLine("The closest to 0 therefore is:");
            Console.WriteLine(values.OrderBy(i => Math.Abs(i)).First());
            Console.Read();
        }
    }
