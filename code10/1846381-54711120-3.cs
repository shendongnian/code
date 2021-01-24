        static void Main()
        {
            List<int> coins = new List<int>();
            List<int> amounts = new List<int>() { 2, 5, 10 };
            //
            // Compute change for 21 cents.
            //
            Change(coins, amounts, 0, 0, 21);
        }
        static void Change(List<int> coins, List<int> amounts, int highest, int sum, int goal)
        {
            //
            // See if we are done.
            //
            if (sum == goal)
            {
                Display(coins, amounts);
                return;
            }
            //
            // See if we have too much.
            //
            if (sum > goal)
            {
                return;
            }
            //
            // Loop through amounts.
            //
            foreach (int value in amounts)
            {
                //
                // Only add higher or equal amounts.
                //
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
                Console.WriteLine("{0}: {1}",
                    amount,
                    count);
            }
            Console.WriteLine();
        }
