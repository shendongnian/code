    class Program
    {
        private int a,b,c,d,e,f;
        public Program()
        {
            a = 1;
            b = 2;
            c = (a + b);
            d = (a - b);
            e = (b / a);
            f = (c * b);
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
