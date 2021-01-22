    public class SomeClass
    {
        private Action<string> _callback;
        public Action<string> Callback
        {
            get
            {
                return _callback;
            }
            set
            {
                if (_callback != null)
                {
                    // the callback is already set; do something about that?
                }
                _callback = value;
            }
        }
    
        public void SomeMethod()
        {
            ExecuteCallback("some data");
        }
    
        private void ExecuteCallback(string data)
        {
            if (_callback != null)
            {
                _callback(data);
            }
        }
    }
