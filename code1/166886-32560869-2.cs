    class Lol
    {
        int i;
        string s;
        public Lol(int ti, string ts)
        {
            i = ti;
            s = ts;
        }
    }
    class Program
    {
        static List<Lol> lol = new List<Lol>();
        static void Main(string[] args)
        {
            for (int i = 0; i < 10000000; ++i)
                lol.Add(new Lol(i, i.ToString()));
            Stopwatch sw = new Stopwatch();
            sw.Start();
            ListCleaner();
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
            for (int i = 0; i < 10000000; ++i)
                lol.Add(new Lol(i, i.ToString()));
            Console.WriteLine("lol");
            ListCleaner();
            for (int i = 0; i < 10000000; ++i)
                lol.Add(new Lol(i, i.ToString()));
            Console.WriteLine("lol");
            ListCleaner();
            for (int i = 0; i < 10000000; ++i)
                lol.Add(new Lol(i, i.ToString()));
            Console.WriteLine("lol");
            ListCleaner();
            for (int i = 0; i < 10000000; ++i)
                lol.Add(new Lol(i, i.ToString()));
            Console.WriteLine("lol");
            ListCleaner();
            for (int i = 0; i < 10000000; ++i)
                lol.Add(new Lol(i, i.ToString()));
            Console.WriteLine("lol");
            ListCleaner();
            for (int i = 0; i < 10000000; ++i)
                lol.Add(new Lol(i, i.ToString()));
            Console.WriteLine("lol");
            ListCleaner();
            for (int i = 0; i < 10000000; ++i)
                lol.Add(new Lol(i, i.ToString()));
            Console.WriteLine("lol");
            ListCleaner();
            for (int i = 0; i < 10000000; ++i)
                lol.Add(new Lol(i, i.ToString()));
            Console.WriteLine("lol");
            ListCleaner();
        }
        static void ListCleaner()
        {
            //lol = new List<Lol>();
            lol.Clear();
        }
    }
