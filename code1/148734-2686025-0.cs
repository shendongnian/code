    int calculatePrice(int n, Dictionary<int, int> prices)
    {
        int[] best = new int[n + prices.Keys.Max()];
        for (int i = 1; i < best.Length; ++i)
        {
            best[i] = int.MaxValue;
            foreach (int amount in prices.Keys.Where(x => x <= i))
            {
                best[i] = Math.Min(best[i],
                    best[i - amount] + prices[amount]);
            }
        }
        return best.Skip(n).Min();
    }
    void Run()
    {
        Dictionary<int, int> prices = new Dictionary<int, int> {
            { 1, 299 },
            { 5, 999 },
            { 10, 1899 },
            { 20, 3499 },
            { 50, 7999 }
        };
        Console.WriteLine(calculatePrice(136, prices));
        Console.WriteLine(calculatePrice(4, prices));
    }
