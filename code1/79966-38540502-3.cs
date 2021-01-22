    class Program
    {
        static void checkPairs(int[] a, int k)
        {
            Dictionary<int, int> Pairs = new Dictionary<int, int>();
            for (int i = 0; i < a.Length; i++)
            {
                if (Pairs.ContainsKey(a[i]))
                {
                    Console.WriteLine(a[i] + ", " + Pairs[a[i]]);
                }
                else
                {
                    Pairs[k - a[i]] = a[i];
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
