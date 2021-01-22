    public class Foo
    {
        public static implicit operator Bar(Foo foo) { return new Bar(); }
    }
    
    public class Bar { }
    
    ...
    
    void Baz()
    {
        Foo foo = new Foo();
    
        Bar bar = foo; // OK
    
        object baz = foo;
    
        bar = baz; // won't compile, there's no defined operator at the object level
    
        bar = (Bar)baz; // will compile, but will fail at runtime for the same reason
    }
