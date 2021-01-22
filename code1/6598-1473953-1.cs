    public delegate T Func<T>();
    
    public static class CustomGlobalActivator<T>
    {
        public static Func<T> CreateInstance { get; set; }
    }
    
    public static class LazyGlobal<T>
    {
        public static T Instance
        {
            get { return TType.Instance; }
        }
    
        private static class TType
        {
            public static readonly T Instance = CustomGlobalActivator<T>.CreateInstance();
        }
    }
    
    {
        // setup code:
        // CustomGlobalActivator<Foo>.CreateInstance = () => new Foo(instanceOf_SL_or_IoC.DoSomeMagicReturning<FooDependencies>());
        CustomGlobalActivator<Foo>.CreateInstance = () => instanceOf_SL_or_IoC.PleaseResolve<Foo>();
        // ...
        // user code:
        LazyGlobal<Foo>.Instance.Bar();
    }
