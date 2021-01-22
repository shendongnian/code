    class Program
    {
        private byte a,b,c,d,e,f;
        public Program()
        {
            a = 1;
            b = 2;
            c = (byte)(a + b);
            d = (byte)(a - b);
            e = (byte)(b / a);
            f = (byte)(c * b);
        }
        static void Main(string[] args)
        {
            int max = 10000000;
            DateTime start = DateTime.Now;
            Program[] tab = new Program[max];
            for (int i = 0; i < max; i++)
            {
                tab[i] = new Program();
            }
            DateTime stop = DateTime.Now;
            Debug.WriteLine(stop.Subtract(start).TotalSeconds);
        }
    }
