    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Foo.Instance.GetHelloWorld());
            Console.ReadLine();
        }
    }
    public class Foo : FooStaticContract<FooFactory>
    {
        public Foo() // Non-static ctor.
        {
        }
        internal Foo(bool st) // Overloaded, parameter not used.
        {
        }
        public override string GetHelloWorld()
        {
            return "Hello World";
        }
    }
    public class FooFactory : IStaticContractFactory<Foo>
    {
        #region StaticContractFactory<Foo> Members
        public Foo CreateInstance()
        {
            return new Foo(true); // Call static ctor.
        }
        #endregion
    }
    public interface IStaticContractFactory<T>
    {
        T CreateInstance();
    }
    public abstract class StaticContract<T, Factory>
        where Factory : IStaticContractFactory<T>, new() 
        where T : class
    {
        private static Factory _factory = new Factory();
        private static T _instance;
        /// <summary>
        /// Gets an instance of this class. 
        /// </summary>
        public static T Instance
        {
            get
            {
                // Scary.
                if (Interlocked.CompareExchange(ref _instance, null, null) == null)
                {
                    T instance = _factory.CreateInstance();
                    Interlocked.CompareExchange(ref _instance, instance, null);
                }
                return _instance;
            }
        }
    }
    public abstract class FooStaticContract<Factory>
        : StaticContract<Foo, Factory>
        where Factory : IStaticContractFactory<Foo>, new() 
    {
        public abstract string GetHelloWorld();
    }
