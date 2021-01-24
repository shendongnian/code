    class Closure
    {
        public int i;
        public int Fn(int j) => i + j;
    }
    static void Main(string[] args)
    {
        List<Func<int, int>> list = new List<Func<int, int>>();
        var c = new Closure();
        for (c.i = 0; c.i < 5; c.i++)
        {
            list.Add(c.Fn);
        }
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine(list[i](i));
        }
    }
