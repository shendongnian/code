    class First
    {
        public int a;
        public int b;
        public int c = 2;
        public Second _second;
        public First()
        {
            _second = new Second(ref a, ref b, c);
        }
    }
    class Second
    {
        public Second(ref int a, ref int b, int c)
        {
            if (c == 0)
            {
                a = 1;
                b = 2;
            }
            else
            {
                a = -1;
                b = -2;
            }
        }
    }
