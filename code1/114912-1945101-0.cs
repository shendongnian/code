    public class A
    {
        public A() { }
    }
    
    public sealed class B : A
    {
        public void A() { }
    }
    
    public class C<T>
            where T : B
    {
        public C() { }
    }
