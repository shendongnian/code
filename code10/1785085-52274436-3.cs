    public interface IBaseInterface
    {
        IBaseInterface ChainableMethod();
    }
    public abstract class AbstractClassThatHelps<T> : IBaseInterface where T : class, IBaseInterface
    {
        public T ChainableMethod()
        {
            return this as T;
        }
        IBaseInterface IBaseInterface.ChainableMethod()
        {
            return ChainableMethod();
        }
    }
    public interface IDerived : IBaseInterface
    {
        IDerived Hello();
    }
    public class DerivedClass : AbstractClassThatHelps<IDerived>, IDerived
    {
        public IDerived Hello()
        {
            Console.WriteLine("Hello");
            return this;
        }
    }
    internal static class Program
    {
        public static void Main()
        {
            AbstractClassThatHelps<IDerived> derived = new DerivedClass();
            derived.ChainableMethod().Hello().ChainableMethod();
        }
    }
