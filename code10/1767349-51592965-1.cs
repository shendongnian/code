    public static CO CardOrder(this string cardOrder)
    {
        switch (cardOrder)
        {
            case "Radom": return CO.Random;
            case "1, 2, 3": return CO.FirstToLast;
            case "3, 2, 1":  return CO.LastToFirst;
        }
        throw new ArgumentException(string.Format($"{cardOrder} is not a CO representation"));
    }
