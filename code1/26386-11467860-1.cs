        public static void doubleTest(int loop)
        {
            Console.Write("double: ");
            for (int i = 0; i < loop; i++)
            {
                double a = 1000, b = 45, c = 12000, d = 2, e = 7, f = 1024;
                a = Math.Sin(a);
                b = Math.Asin(b);
                c = Math.Sqrt(c);
                d = d + d - d + d;
                e = e * e + e * e;
                f = f / f / f / f / f;
            }
        }
        public static void floatTest(int loop)
        {
            Console.Write("float: ");
            for (int i = 0; i < loop; i++)
            {
                float a = 1000, b = 45, c = 12000, d = 2, e = 7, f = 1024;
                a = (float) Math.Sin(a);
                b = (float) Math.Asin(b);
                c = (float) Math.Sqrt(c);
                d = d + d - d + d;
                e = e * e + e * e;
                f = f / f / f / f / f;
            }
        }
        static void Main(string[] args)
        {
            DateTime time = DateTime.Now;
            doubleTest(5 * 1000000);
            Console.WriteLine("milliseconds: " + (DateTime.Now - time).TotalMilliseconds);
            time = DateTime.Now;
            floatTest(5 * 1000000);
            Console.WriteLine("milliseconds: " + (DateTime.Now - time).TotalMilliseconds);
            Thread.Sleep(5000);
        }
