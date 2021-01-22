    using System;
    using System.Drawing;
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var n in Enum.GetNames(typeof(ConsoleColor)))
                Console.WriteLine("{0,-12} #{1:X6}", n, Color.FromName(n).ToArgb() & 0xFFFFFF);
        }
    }
