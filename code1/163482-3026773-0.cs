    public void Method()
    {
     Foo a = new Foo( ViewSomething );
    }
    
    // ...
    public class Foo
    {
        public Foo( Delegate1 del ) // note: accepting the delegate parameter
        {
            DelegateHandler = del;
        }
    }
    public delegate void Delegate1(T t);
    
    public Delegate1 Delegate1Handler { get; set; }
