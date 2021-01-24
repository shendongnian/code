    using System;
    using System.Linq;
    
    namespace ConsoleApp1
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                var colors = Enum.GetValues(typeof(ConsoleColor)).Cast<ConsoleColor>().ToArray();
    
                foreach (var color in colors)
                {
                    Console.ForegroundColor = color;
    
                    Console.Write("ABC");
                }
            }
        }
    }
