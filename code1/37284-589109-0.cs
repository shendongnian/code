    class Program
    {
        static void Main(string[] args)
        {
            byte[] b = new byte[1000];
            dowork(b.Take(10).ToArray());
        }
        public static void dowork(byte[] b)
        {
            // do some work
        }
    }
