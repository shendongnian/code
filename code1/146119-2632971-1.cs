    static void Foo()
    {
        Console.WriteLine("Hello World!");
    }
    static Action Bar()
    {
        return new Action(Foo);
    }
    static void Main()
    {
        Func<Action> func = new Func<Action>(Bar);
        func()();
        Bar()();
    }
