    class Base {
    }
    
    class Derived : Base {
    }
    
    void DoSomething(Base x) {
        Console.WriteLine("Base!");
    }
    
    void DoSomething(Derived x) {
        Console.WriteLine("Derived!");
    }
    
    void DoSomething<T>() where T: Base, new() {
        dynamic x = new T();
        DoSomething(x);
    }
    
    void Main()
    {
        DoSomething<Base>();
        DoSomething<Derived>();
    }
