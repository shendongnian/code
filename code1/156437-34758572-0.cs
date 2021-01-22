    using System;
    using java.math;
    namespace BigDecimalDemo
    {
        class Program
        {
            static void Main(string[] args)
            {
                int n = int.Parse(args[0]);
                Console.WriteLine(Factorial(n));
            }
            static BigDecimal Factorial(int n)
            {
                return n == 1
                    ? BigDecimal.ONE
                    : Factorial(n - 1).multiply(new BigDecimal(n));
            }
        }
    }
