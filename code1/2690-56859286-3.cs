    [Flags]
    public enum A : uint
    {
        None  = 0 
        X     = 1 < 0,
        Y     = 1 < 1
    }
    
    static void Main(string[] args)
    {
        var value = EnumHelper.ToEnum<A>(7m);
        var x = value.HasFlag(A.X); // true
        var y = value.HasFlag(A.Y); // true
        var value2 = EnumHelper.ToEnum<A>("X");
        var value3 = EnumHelper.ToEnum<A>(null);
        Console.ReadKey();
    }
