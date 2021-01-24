    public static void M(Action action) { /* do stuff */ }
    public static void M(Func<int> func) { /* do stuff */ }
    public static void Main()
    {
        M(action: () => throw new Exception());
    }
