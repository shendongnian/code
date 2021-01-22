    public enum MyEnum : short
    {
        Mek = 5
    }
    static void Main(string[] args)
    {
        var e1 = (MyEnum)32769; // will not compile, out of bounds for a short
        object o = 5;
        var e2 = (MyEnum)o;     // will throw at runtime, because o is of type int
        Console.WriteLine("{0} {1}", e1, e2);
        Console.ReadLine();
    }
