    public class BaseClass
    {
        public event EventHandler SomeEvent;
    }
    
    public class MyClass : BaseClass
    {
        private int _refCount = 0;
        public new event EventHandler SomeEvent
        {
            add
            {
                if (_refCount > 0)
                {
                    // handler already attached
                }
                base.SomeEvent += value;
                _refCount++;
            }
            remove
            {
                base.SomeEvent -= value;
                _refCount--;
            }
        }
    }
