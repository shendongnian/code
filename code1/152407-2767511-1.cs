        public enum Comparison
        {
            GreaterThan,
            LessThan
        }
        public bool Compare(int a, Comparison c, int b)
        {
            if (c == Comparison.GreaterThan)
                return a > b;
            else if (c == Comparison.LessThan)
                return a < b;
            else
                throw new ArgumentException();
        }
        public void Run()
        {
            int i = 50;
            int increment = -1;
            int l = 0;
            Comparison c = Comparison.GreaterThan;
            for (i; Compare(i, c, l); i = i + increment)
            {
            }
        }
