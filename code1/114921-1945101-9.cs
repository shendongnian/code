    public class A
    {
        public A() { }
    }
    
    public sealed class B : A
    {
        public B() { }
    }
    
    public class C<T>
            where T : B
    {
        public C() { }
    }
