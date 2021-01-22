    public static class LazyGlobal<T> where T : new()
    {
        public static T Instance
        {
            get { return TType.Instance; }
        }
    
        private static class TType
        {
            public static readonly T Instance = new T();
        }
    }
    
    // user code:
    {
        LazyGlobal<Foo>.Instance.Bar();
    }
