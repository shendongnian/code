    class Program
    {
        static void Main(string[] args)
        {
            var size = 16;
            var tmpList = Enumerable.Range(size / 2, size / 2).ToList();
            var result = new List<Pair>();
            for (int i = 1; i <= size / 2; i++ )
            {
                var pair = new Pair() { a = i, b = PopRandom(tmpList) };
                result.Add(pair);
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
