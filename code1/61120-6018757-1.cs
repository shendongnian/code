    public sealed class MyClass
    {    
        #region make singleton
        
        static readonly Lazy<MyClass> _singleton =
            new Lazy<MyClass>(() => new MyClass());
        public static MyClass Singleton
        {
            get { return _singleton.Value; }
        }
        private MyClass() { Initialize() };
        #endregion
        Initialize() { /*TODO*/ };
    }
