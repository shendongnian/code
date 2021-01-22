    `private static List<Tuple<int, string>> ZeroesAndLetters = new List<Tuple<int, string>>()
    {
        new Tuple<int, string>(15, "Q"),
        new Tuple<int, string>(12, "T"),
        new Tuple<int, string>(9, "B"),
        new Tuple<int, string>(6, "M"),
        new Tuple<int, string>(3, "K"),
    };
    public static string GetPointsShortened(ulong num)
    {
        int zeroCount = num.ToString().Length;
        for (int i = 0; i < ZeroesAndLetters.Count; i++)
            if (zeroCount >= ZeroesAndLetters[i].Item1)
                return (num / Math.Pow(10, ZeroesAndLetters[i].Item1)).ToString() + ZeroesAndLetters[i].Item2;
        return num.ToString();
    }`
