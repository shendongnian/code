        private object _someProperty;
        public object SomeProperty
        {
            get
            {
                return _someProperty;
            }
            private set
            {
                if (_someProperty != value)
                {
                  OnSettingSomeProperty(_someProperty, value);
                  OnSomeEventHappens(EventArgs.Empty);
                  _someProperty = value;
                }
            }
        }
    
        protected virtual void OnSettingSomeProperty(object oldValue, object newValue)
        {
            // children can play here, validate and throw, etc.
        }
