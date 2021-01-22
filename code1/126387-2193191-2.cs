    void NewMethod(ref S s)
    {
        Blah(s);
        Bar(s);
        s.M();
    }
    void Foo() 
    {
        S s = new S();
        Fred(s);
        NewMethod(ref s);
        Console.WriteLine(s.X()); // still prints 1
    }
