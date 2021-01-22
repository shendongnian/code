    public class MyClass
    {
        public int PropName { get; set; }
    }
    
    public void Foo(MyClass bar)
    {
        bar.PropName = 5;
    }
    
    ...
    
    MyClass baz = new MyClass();
    
    baz.PropName = 2;
    
    Foo(baz);
    
