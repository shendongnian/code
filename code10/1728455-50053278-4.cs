    using System;
    using System.IO;
    namespace TestConsoleProject
    {
        class Program
        {
            static void Main(string[] args)
            {
                var lines = File.ReadLines(args[0]);
                var reader = new WeirdLineFormatReader();
                var tuples = reader.ReadLines(lines);
                foreach (var tuple in tuples)
                    Console.WriteLine("{0} - {1}", tuple.Item1, tuple.Item2);
                Console.ReadKey();
            }
        }
    }
