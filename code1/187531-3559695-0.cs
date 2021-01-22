    class Foo
    {
        int? _cachedResult = null;
    
        int _someProperty;
        public int SomeProperty
        {
            get { return _someProperty; }
            set { _someProperty = value; _cachedResult = null; }
        }
    
        int _someOtherProperty;
        public int SomeProperty
        {
            get { return _someOtherProperty; }
            set { _someOtherProperty = value; _cachedResult = null; }
        }
    
        public int SomeDerivedProperty
        {
            get
            {
                if (_cachedResult == null)
                    _cachedResult = someExpensiveCalculation();
    
                return _cachedResult;
            }
        }
    }
