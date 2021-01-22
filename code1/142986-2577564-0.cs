    using System;
    using System.Collections.Generic;
    class TestArrayAncestry
    {
        static void Main(string[] args)
        {
            int[] values = new[] { 1, 2, 3 };        
            Console.WriteLine("int[] is IList<int>: {0}", values is IList<int>);
        }
    }
