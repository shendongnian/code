    class Class1
    {
        private bool _isReadOnly;
        private int _property1;
        public int Property1
        {
            get
            {
                return _property1;
            }
            set
            {
                if (_isReadOnly) 
                  throw new Exception("At the moment this is ready only property.");
                _property1 = value;
            }
        }
    }
