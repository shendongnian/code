    public static Boolean[] Initialize(Int32 n, Int32 k)
    {
        return Enumerable.Concat(Enumerable.Repeat(true, k),
                                 Enumerable.Repeat(false, n - k)).ToArray();
    }
