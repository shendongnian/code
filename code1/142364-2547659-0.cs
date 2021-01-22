    public class C
    {
    }
    
    public class D : C
    {
    }
    
    public class A<T> where T:C
    {
        public T Argument { get; set; }
    }
    
    public class B : A<D>
    {
        public D Argument { get; set; }
    }
