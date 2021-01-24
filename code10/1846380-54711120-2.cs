    static List<int> resultCoins = new List<int>();
        static void Main()
        {
            List<int> amounts = new List<int>() { 2, 5, 10 };
            Change(new List<int>(), amounts, 0, 0, 21);
            Display(resultCoins, amounts);
        }
        static void Change(List<int> coins, List<int> amounts, int highest, int sum, int goal)
        {
            if (sum == goal)
            {
                resultCoins = coins;
                return;
            }
            if (sum > goal)
            {
                return;
            }
            foreach (int value in amounts)
            {
                if (value >= highest)
                {
                    List<int> copy = new List<int>(coins);
                    copy.Add(value);
                    Change(copy, amounts, value, sum + value, goal);
                }
            }
        }
        static void Display(List<int> coins, List<int> amounts)
        {
            foreach (int amount in amounts)
            {
                int count = coins.Count(value => value == amount);
                Console.WriteLine("{0}: {1}", amount, count);
            }
            Console.WriteLine();
        }
