    public sealed class MyClass
    {    
        #region make singleton
        
        static readonly Lazy<Analyzer> _singleton = new Lazy<Analyzer>(() => new Analyzer());
        public static Analyzer Singleton { get { return _singleton.Value; } }
        private MyClass() { Initialize() };
        #endregion
        Initialize() { /*TODO*/ };
    }
