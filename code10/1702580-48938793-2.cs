    public static void Main(string[] args)
    {
        String foo = "abc";
        DoSomething(out foo);
        Console.WriteLine(foo);
    }
        
    private static void DoSomething(out String something)
    {
        something = "def";
    }
