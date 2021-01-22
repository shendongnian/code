    void MyMethod() { Console.WriteLine("Hi!"); }
    
    void Foo()
    {
        Action a = MyMethod;
        a();
    }
