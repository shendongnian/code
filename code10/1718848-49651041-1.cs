    public class ThreadSafeGeneric<T>
    {
        private T _myObject;
        public T MyObject
        {
            get
            {
                lock (_myObject)
                {
                    return _myObject;
                }
            }
            set
            {
                lock (_myObject)
                {
                    _myObject = value;
                }
            }
        }
    }
