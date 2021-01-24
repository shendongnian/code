    public class Second
    {
        public Second(int a, int b, int c)
        {
            // old constructor if still needed
            ...
        }
        public Second(First f)
        {
            int sign = f.c == 0 ? 1 : -1;
            f.a = 1 * sign;
            f.b = 2 * sign;
        }
    }
