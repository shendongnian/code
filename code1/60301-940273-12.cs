    public class Foo
    {
        private readonly static Dictionary<Type, Command> factories =
            new Dictionary<Type, Command>();
        static Foo()
        {
            factories.Add(typeof(IAlpha), new AlphaCreationCommand());
            factories.Add(typeof(IBeta), new BetaCreationCommand());
        }
        public T Bar<T>()
        {
            if (factories.ContainsKey(typeof(T)))
            {
                return (T) factories[typeof(T)].Execute();
            }
            throw new TypeNotSupportedException(typeof(T));
        }
    }
    // use it like this
    IAlpha alphaInstance = myFoo.Bar<IAlpha>();
    IBeta betaInstance = myFoo.Bar<IBeta>();
