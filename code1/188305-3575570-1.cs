    [Flags]
    enum Foo{
        A = 1,
        B = 2,
        C = 4,
        D = 8
    }
    Foo x = Foo.A | Foo.B | Foo.C | Foo.D;
    int i = (int)x;
    string s = x.ToString();
    Console.WriteLine(i);
    Console.WriteLine(s);
    Console.WriteLine((Foo)Enum.Parse(typeof(Foo), i.ToString()) == x);
    Console.WriteLine((Foo)Enum.Parse(typeof(Foo), s) == x);
