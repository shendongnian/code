    public static bool CoinToss(this Random rng)
    {
        return rng.Next(2) == 0;
    }
    public static T OneOf<T>(this Random rng, params T[] things)
    {
        return things[rng.Next(things.Length)];
    }
    Random rand;
    bool luckyDay = rand.CoinToss();
    string babyName = rand.OneOf("John", "George", "Radio XBR74 ROCKS!");
