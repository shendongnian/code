    class Program
    {
        static void Main(string[] args)
        {
            var size = 16;
            var list = Enumerable.Range(1, size + 1).ToList();
            var result = new List<Pair>();
            while (size > 0)
            {
                var pair = new Pair() { a = PopRandom(list), b = PopRandom(list) };
                result.Add(pair);
                size -= 2;
            }
            Console.WriteLine(result);
        }
        static private int PopRandom(List<int> list)
        {
            var r = new Random();
            var i = r.Next(0, list.Count);
            
            var result = list[i];
            list.RemoveAt(i);
            return result;
        }
        struct Pair
        {
            public int a;
            public int b;
        }
    }
