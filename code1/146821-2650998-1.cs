    struct S
    {
        private int x;
        public static void M(ref S THIS)
        {
            THIS.x = 123;
        }
    }
    ...
    S s = new S();
    S.M(ref s);
