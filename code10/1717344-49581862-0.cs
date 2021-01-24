    static int F1(int n, string steps)
    {
        int ways = 0;
        if (n > 2) ways += F1(n - 3, steps + "3");
        if (n > 1) ways += F1(n - 2, steps + "2");
        if (n < 0) throw new InvalidOperationException();
        if (n == 0)
        {
            Console.WriteLine(steps);
            ways = 1;
        }
        // else: no dice, invalid outcome
        return ways;
    }
