    class Program
    {
        public static void Main(string[] args)
        {
            int[] a = { 10, 20, 30 };
            int[] b = { 2, 4, 10 };
            int[] c = a.MatrixMultiply(b);
            int[] c2 = a.Zip(b, (p1, p2) => p1 * p2);
        }
    }
    public static class Extension
    {
        public static int[] MatrixMultiply(this int[] a, int[] b)
        {
            // TODO: Add guard conditions
            int[] c = new int[a.Length];
            for (int x = 0; x < a.Length; x++)
            {
                c[x] = a[x] * b[x];
            }
            return c;
        }
        public static R[] Zip<A, B, R>(this A[] a, B[] b, Func<A, B, R> func)
        {
            // TODO: Add guard conditions
            R[] result = new R[a.Length];
            for (int x = 0; x < a.Length; x++)
            {
                result[x] = func(a[x], b[x]);
            }
            return result;
        }
    }
