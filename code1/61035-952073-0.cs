    using System;
    
    namespace ConsoleApplication10
    {
        public enum X { A, B, C, D }
        public class Program
        {
            static void Main()
            {
                var x = X.D + X.A;
                Console.Out.WriteLine(x);
                Console.In.ReadLine();
            }
        }
    }
