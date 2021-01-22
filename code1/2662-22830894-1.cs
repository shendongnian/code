    public enum MyEnum : int
    {
        Foo = 1,
        Bar = 2,
        Mek = 5
    }
    static void Main(string[] args)
    {
        var e1 = (MyEnum)5;
        var e2 = (MyEnum)6;
        Console.WriteLine("{0} {1}", e1, e2);
        Console.ReadLine();
    }
