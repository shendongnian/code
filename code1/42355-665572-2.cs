    public static bool IsNegative(int x)
    {
        return x < 0;
    }
    static void Main(string[] args)
    {
        Predicate<int> p = IsNegative;
        Func<int, bool> f = IsNegative;
        p = f; // Not allowed
    }
