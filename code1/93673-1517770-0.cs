    public static IEnumerable<int> veryComplicatedFunction()
    {
        List<string> l = new List<string> { "1", "2", "3" };
        foreach (var item in l)
        {
            yield return item;
        }
    }
