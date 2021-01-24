    using System;
    using System.Threading.Tasks;
    namespace Demo
    {
        class Program
        {
            static void Main()
            {
                Console.WriteLine();
                Random rng = new Random(12345);
                Parallel.Invoke(
                    () => printRandomNumbers(rng),
                    () => printRandomNumbers(rng),
                    () => printRandomNumbers(rng));
                Console.ReadLine();
            }
            static void printRandomNumbers(Random rng)
            {
                while (rng.Next() != 0)
                {}
                while (true)
                {
                    Console.WriteLine(rng.Next());
                }
            }
        }
    }
