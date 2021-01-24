    static class Program
    {
        static void Main()
        {
            var powerSet = "abc".ToList().PowerSet();
            foreach (var set in powerSet)
            {
                // set will be a list of chars, which is equivalent to a string
                Console.WriteLine($"{new string(set.ToArray())}");
            }
            Console.ReadLine();
        }
    }
