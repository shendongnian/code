    class Program
    {
        static void Main(string[] args)
        {
            var q = new Test[] { Test.One, Test.Two, Test.Two };
            var e = q.AsQueryable().GroupBy(x => x).Select(x => new
            {
                Name = x.Key.ToString(),
                Amount = x.Count()
            });
            foreach (var x in e)
            {
                Console.WriteLine(x.Name);
            }
            Console.ReadLine();
        }
    }
    enum Test
    {
        One,
        Two
    }
