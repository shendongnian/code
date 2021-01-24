    enter code here
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            //Console.WriteLine(N);
            int a = N % 10;
            int b = ((N / 10) % 10);
            int c = ((N / 100) % 10);
            int sum = 0;
            //Console.WriteLine(X);
            //Console.WriteLine(Y);
            //Console.WriteLine(Z);
            if ((a > 1) && (b > 1) && (c > 1))
            {
                Console.WriteLine(a * b * c);
            }
            if ((a == 0) && ((b <= 1) || (c <= 1)))
            {
                Console.WriteLine(b + c);
            }
            if ((a == 0) && ((b > 1) && (c > 1)))
            {
                Console.WriteLine(b * c);
            }
            if ((a == 1) && (b > 1) && (c > 1))
            {
                Console.WriteLine(a + b * c);
            }
            if ((a == 1) && ((b <= 1) || (c <= 1)))
            {
                Console.WriteLine(a + b + c);
            }
            if ((a > 1) && ((b <= 1) && (c <= 1)))
            {
                Console.WriteLine(a + b + c);
            }
            if ((a > 1) && (b == 1) && (c > 1))
            {
                Console.WriteLine(a * b * c);
            }
            if ((a > 1) && (b == 0) && (c > 1))
            {
                Console.WriteLine(a + b + c);
            }
            if ((a > 1) && (b > 1) && (c <= 1))
            {
                Console.WriteLine(a * b + c);
            }
        }
    }
