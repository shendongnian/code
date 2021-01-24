    class MyClass
    {
        private readonly ILoggerFactory _loggerFactory;
        public MyClass():this(NullLoggerFactory.Instance)
        {
        
        }
        public MyClass(ILoggerFactory loggerFactory)
        {
          this._loggerFactory = loggerFactory ?? NullLoggerFactory.Instance;
        }
    }
