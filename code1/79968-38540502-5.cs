    using System;
    using System.Collections.Generic;
    class Program
    {
        static void checkPairs(int[] input, int k)
        {
            Dictionary<int, int> Pairs = new Dictionary<int, int>();
            for (int i = 0; i < input.Length; i++)
            {
                if (Pairs.ContainsKey(input[i]))
                {
                    Console.WriteLine(input[i] + ", " + Pairs[input[i]]);
                }
                else
                {
                    Pairs[k - input[i]] = input[i];
                }
            }
        }
        static void Main(string[] args)
        {
            int[] a = { 2, 45, 7, 3, 5, 1, 8, 9 };
            //method : codaddict's algorithm : O(n)
            checkPairs(a, 10);
            Console.Read();
        }
    }
