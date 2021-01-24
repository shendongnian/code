    public static bool Check(string hex)
    {
       return Enumerable.Range(0, hex.Length-2)
                               .Where(x => x % 2 == 0)
                               .Select(x => Convert.ToInt32(hex.Substring(x, 2), 16))
                               .Aggregate((i, i1) => i ^ i1)
                               .ToString("x") == hex.Substring(hex.Length-2);
    }
