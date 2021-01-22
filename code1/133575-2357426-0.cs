    static void Main(string[] args)
    {
        Console.WriteLine(1.IsGreaterThan(2));
        Console.WriteLine(1.IsLessThan(2));
    }
    
    public static bool IsGreaterThan<T>(this T value, T other) where T : IComparable
    {
        return value.CompareTo(other) > 0;
    }
    
    public static bool IsLessThan<T>(this T value, T other) where T : IComparable
    {
        return value.CompareTo(other) < 0;
    }
