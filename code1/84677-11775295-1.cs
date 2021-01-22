    class Program
    {
        static void Main(string[] args)
        {
            var someNumbers = Enumerable.Range(0, 10000);
            foreach (var block in someNumbers.Partition(100))
            {
                Console.WriteLine("\nStart of block.");
                foreach (int number in block)
                {
                    Console.Write(number);
                    Console.Write(" ");
                }
            }
            Console.WriteLine("\nDone.");
            Console.ReadLine();
        }
    }
