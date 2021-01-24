    public interface IMyInterface<T>
    {
        void Method();
    }
    public class A { }
    public class B { }
    public class C { }
    public class D { }
    public class MyAClass : IMyInterface<A>
    {
        public void Method()
        {
        }
    }
    public class MyBClass : IMyInterface<B>
    {
        public void Method()
        {
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            IMyInterface<A> myInterface = new MyAClass();
            myInterface.Method();
        }
    }
