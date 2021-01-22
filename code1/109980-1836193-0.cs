    public class Base
    {
        protected int Foo;
    }
    
    public class Der : Base
    {
        private void B(Base b) { Foo = ((Der)b).Foo; } // Works now
    
        private void D(Der d) { Foo = d.Foo; } // OK
    }
