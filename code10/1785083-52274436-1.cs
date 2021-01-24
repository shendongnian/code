    public interface IBaseInterface
    {
        IBaseInterface ChainableMethod();
    }
    
    public abstract class AbstractClassThatHelps : IBaseInterface
    {
        public IBaseInterface ChainableMethod()
        {
            return this;
        }
    }
    
    public interface IDerived : IBaseInterface
    {
    
    }
    
    public class DerivedClass : AbstractClassThatHelps, IDerived
    {
    
    }
    
    
    internal static class Program
    {
        public static void Main()
        {
    
            IDerived derived = new DerivedClass();
            derived.ChainableMethod().ChainableMethod();
        }
    }
