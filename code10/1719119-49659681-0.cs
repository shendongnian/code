    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    public enum Col { Red, Yellow, White }
    public static class ColExtension
    {
        public static Col Next(this Col col)
        {
            if (col == Col.Red)
                return Col.Yellow;
            if (col == Col.Yellow)
                return Col.White;
            return Col.Red;
        }
    }
    internal class Program
    {
        public
        static void Main(string[] args)
        {
            int[] x = new int[101];
            // create numbers ranging from 1 to 100. Pseudo-randomize order by ordering after randomized generated value
            var numbers = Enumerable.Range(1, 100).OrderBy(n => Guid.NewGuid().GetHashCode()).ToArray();
            // start-color for the first one
            var aktCol = Col.Red;
            var mapping = new Dictionary<int, Col>();
            foreach (var number in numbers)
            {
                // assign first color
                mapping[number] = aktCol;
                // advance color 
                aktCol = aktCol.Next(); 
            }
            foreach (var num in numbers)
                Console.WriteLine($"{num}, {mapping[num]}");
            Console.ReadLine();
        }
    }
