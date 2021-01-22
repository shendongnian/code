    public static IEnumerable<string> Numbers()
    {
        return Enumerable.Range(0xA0000, 0xFFFF9 - 0xA0000 + 1)
            .Select(x => x.ToString("X"));
    }
