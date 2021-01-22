    public static void Main()
    {
        Console.WriteLine(new Foo() == new Foo());
        Console.WriteLine(new Foo() == null);
        Console.WriteLine(5 == null);
        Console.WriteLine(new Foo() != null);
    }
