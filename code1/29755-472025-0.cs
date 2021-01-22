    public static IEnumerable<int> GetRandom()
    {
        var rand = new Random();
        while (true)
        {
            yield return
            rand.Next(1, 9);
        }
    }
    public static List<int> GetThirtyThatAddToTwoHundred()
    {
        do
        {
            var current = GetRandom().Take(30);
            if (200 == current.Sum())
            {
                return current.ToList();
            }
        } while (true);
    }
