    public class SomeProxy
    {
        public SomeProxy(ExternalObject obj)
        {
             _obj = obj;
        }
        
        public event EventArgs PropertyChanged;
        private bool _lastValue;
        private ExternalObject _obj;
        
        protected virtual void OnPropertyChanged()
        {
            if(PropertyChanged != null)
                PropertyChanged();
        }
        protected virtual void PreMethodCall()
        {
            _lastValue = _obj.SomeProperty;
        }
        protected virtual void PostMethodCall()
        {
            if(_lastValue != _obj.SomeProperty)
                OnPropertyChanged();
        }
        // Proxy method.
        public SomeMethod(int arg)
        {
            PreMethodCall();
            _obj.SomeMethod(arg); // Call actual method.
            PostMethodCall();
        }
    }
    
