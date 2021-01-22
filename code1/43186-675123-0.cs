    public interface IFoo
    {
        void SomeMethod();
    }
    
    public class Foo : MarshalByRefObject, IFoo
    {
        public Foo()
        {
        }
    
        public void SomeMethod()
        {
            Console.WriteLine("In Other AppDomain");
        }
    }
