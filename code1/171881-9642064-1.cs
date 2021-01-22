    public interface IInterface
    {
        void CommonMethod();
        void SpecificMethod();
    }
    public abstract class CommonImpl
    {
        public void CommonMethod() // note: it isn't even virtual here!
        {
            Console.WriteLine("CommonImpl.CommonMethod()");
        }
    }
    public class Concrete : CommonImpl, IInterface
    {
        void SpecificMethod()
        {
            Console.WriteLine("Concrete.SpecificMethod()");
        }
    }
