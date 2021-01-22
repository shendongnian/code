    class Program
    {
        static void Main(string[] args)
        {
            int size = 8;
            List<int> tmpList = new List<int>();
            for (int i = size; i <= size * 2; i++)
            {
                tmpList.Add(i);
            }
            List<Pair> result = new List<Pair>();
            for (int i = 1; i <= size; i++)
            {
                Pair pair = new Pair() { a = i, b = PopRandom(tmpList) };
                result.Add(pair);
            }
        }
        static private int PopRandom(List<int> list)
        {
            Random r = new Random();
            int i = r.Next(0, list.Count);
            int result = list[i];
            list.RemoveAt(i);
            return result;
        }
        struct Pair
        {
            public int a;
            public int b;
        }
    }
