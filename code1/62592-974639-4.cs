    void Foo()
    {
        Action a = delegate { Console.WriteLine("Hi!"); }
        a();
    }
