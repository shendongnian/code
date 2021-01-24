    using System;
    
    namespace IdentifyIATA
    {
        class Program
        {
            static void Main(string[] args)
            {
                var result = Iata.CodeIdentifier(args[0]);
                Console.WriteLine($"Code: {result.Item1}, {result.Item2} ");
                Console.ReadLine();
            }
        }
    }
