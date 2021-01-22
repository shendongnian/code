    class Test
    {
        private static void Main()
        {
            double x = 0.0;
            for (int i = 0; i < 10; ++i)
                x += 0.1;
            Console.WriteLine("x = {0}, expected x = {1}, x == 1.0 is {2}", x, 1.0, x == 1.0);
            Console.WriteLine("Allowing for a small error: x == 1.0 is {0}", Math.Abs(x - 1.0) < 0.001);
        }
    }
