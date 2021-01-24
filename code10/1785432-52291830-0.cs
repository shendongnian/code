    using System;
    using System.Linq;
    
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var input = new string[] { "AB-PQ", "PQ-EF", "EF=CD", "CD-IJ", "IJ=XY", "XY-JK" };
                var output = input[0] + string.Join("", input.Skip(1).Select(c => string.Join("", c.Skip(2))));
                Console.WriteLine(output);
                Console.ReadLine();
            }
        }
    }
