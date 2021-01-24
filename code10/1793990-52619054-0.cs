    class Foo { public int Value; }
    public static void ReplaceFoo(ref Foo foo)
    {
        foo = new Foo { Value = 2 };
    }
    var foo = new Foo { Value = 1 };
    Console.WriteLine(foo.Value);
    ReplaceFoo(ref foo);
    Console.WriteLine(foo.Value);
