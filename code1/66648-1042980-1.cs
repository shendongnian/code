    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("primes.txt"))
            {
                foreach (var prime in GetPrimes(10, reader))
                {
                    Console.WriteLine(prime);
                }
            }
        }
        public static IEnumerable<short> GetPrimes(short upTo, StreamReader reader)
        {
            int count = 0;
            string line = string.Empty;
            while ((line = reader.ReadLine()) != null && count++ < upTo)
            {
                yield return short.Parse(line);
            }
        }
    }
