    class Program
    {
        static void Main(string[] args)
        {
            List<int> testList = new List<int>();
    
            for (int i = 1; i <= 1000; ++i)
            {
                testList.Add(1);
            }
    
            Console.WriteLine(subsetSum.Find(testList, 0, 1000));
            Console.WriteLine(subsetSum.Find(new List<int>() {1, 2, 3, 4, 5, 6}, 0, 21));
        }
    }
    
    static class subsetSum
    {
        private static Dictionary<Tuple<int, int>, bool> memo;
    
        static subsetSum()
        {
            memo = new Dictionary<Tuple<int, int>, bool>();
        }
    
        public static bool Find(List<int> inputArray, int n, int sum)
        {
            if (sum == 0)
            {
                return true;
            }
            else if (sum < 0)
            {
                return false;
            }
    
            if (n >= inputArray.Count)
            {
                return false;
            }
    
            Tuple<int, int> state = new Tuple<int, int>(n, sum);
            if (memo.ContainsKey(state))
            {
                return memo[state];
            }
    
            memo[state] = Find(inputArray, n + 1, sum) || Find(inputArray, n + 1, sum - inputArray[n]);
            return memo[state];
        }
    }
