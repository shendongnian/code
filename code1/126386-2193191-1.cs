    void Foo() 
    {
        S s = new S();
        Fred(s);
        Blah(s);
        Bar(s);
        s.M();
        Console.WriteLine(s.X()); // prints 1
    }
