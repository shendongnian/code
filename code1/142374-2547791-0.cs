    public class C
    {
        public int foo;
    }
    public class D : C
    {
    }
    public class A : ITest<C>
    {
        public C foo { get; private set; }
    }
    public class B : ITest<D>
    {
        public D foo { get; private set; }
    }
    public interface ITest<out T> where T : C
    {
        T foo { get; }
    }
    static class Program
    {
        public static void Covariance(ITest<C> test)
        {
        }
        static void Main()
        {
            A myCVar = new A();
            B myDVar = new B();
            Covariance(myDVar);
        }
    }
Note that the Covariance function will accept a B (which is an ITest&lt;D&gt;, not an ITest&lt;C&gt;), because the ITest interface has marked the T parameter with the keyword out. This tells the compiler that this type parameter will *only* be used in output operations, so it is safe to substitute any derived class of T when using this interface.
