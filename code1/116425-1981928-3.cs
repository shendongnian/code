    public void Foo(ref MyClass bar)
    {
        bar = new MyClass();
    
        bar.PropName = 5;
    }
    
    ...
    
    MyClass baz = new MyClass();
    
    baz.PropName = 2;
    
    Foo(ref baz);
