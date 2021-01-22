    class Program
    {
        // Calculate (20!) 1 million times using both methods.
        static void Main(string[] args)
        {
            Stopwatch sw = Stopwatch.StartNew();
            Int64 result = 0;
            for (int i = 0; i < 1000000; i++)
                result += FactR(20);
            Console.WriteLine("Recursive Time: " + sw.ElapsedMilliseconds);
            sw = Stopwatch.StartNew();
            result = 0;
            for (int i = 0; i < 1000000; i++)
                result += FactG(20);
            Console.WriteLine("Goto Time: " + sw.ElapsedMilliseconds);
            Console.ReadLine();
        }
        // Recursive Factorial
        static Int64 FactR(Int64 i)
        {
            if (i <= 1)
                return 1;
            return i * FactR(i - 1);
        }
        // Recursive Factorial (using GOTO)
        static Int64 FactG(Int64 i)
        {
            Int64 result = 1;
        Loop:
            if (i <= 1)
                return result;
            result *= i;
            i--;
            goto Loop;
        }
