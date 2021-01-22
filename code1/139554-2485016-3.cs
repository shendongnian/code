    class Program
    {
        static bool IsPandigital(int n)
        {
            int digits = 0;
            int count = 0;
            for (; n > 0; n /= 10)
            {
                digits |= 1 << (n - ((n / 10) * 10) - 1);
                ++count;
            }
            return digits == (1 << count) - 1;
        }
        
        static void Main()
        {
            int pans = 0;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 123456789; i <= 123987654; i++)
            {
                if (IsPandigital(i))
                {
                    pans++;
                }
            }
            sw.Stop();
            Console.WriteLine("{0}pcs, {1}ms", pans, sw.ElapsedMilliseconds);
            Console.ReadKey();
        }
    }
