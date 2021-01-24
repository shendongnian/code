    public interface IBaseInterface
    {
        IBaseInterface ChainableMethod();
    }
    
    public abstract class AbstractClassThatHelps<T> : IBaseInterface where T : IBaseInterface
    {
        public IBaseInterface ChainableMethod()
        {
            return this;
        }
    }
    
    public interface IDerived : IBaseInterface
    {
    
    }
    
    public class DerivedClass : AbstractClassThatHelps<IDerived>, IDerived
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
