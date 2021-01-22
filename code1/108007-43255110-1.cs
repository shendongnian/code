    public static void Main()
    {
        string x = null;
        string y = String.Empty;
        Console.WriteLine($"Standard string comparison: {StringComparer.Ordinal.Equals(x, y)}");
        IEqualityComparer<string> equalityComparer = new NullStringComparer();
        Console.WriteLine($"My string comparison {equalityComparer.Equals(x, y)}");
        int hashX = equalityComparer.GetHashCode(x);
        int hashY = equalityComparer.GetHashCode(y);
        Console.WriteLine($"hash X = {hashX}, hash Y = {hashY}");
    } 
