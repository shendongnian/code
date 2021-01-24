    public class ThreadSafeObject
    {
        private object _myObject; //Must be reference type
        public object MyObject
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
