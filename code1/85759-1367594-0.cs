    public class MyClass
    {
        private int _myValue;
        public int MyProperty
        {
            get
            {
                lock(this)
                {
                    return _myValue;
                }
            }
            set
            {
                lock(this)
                {
                    _myValue = value;
                }
            }
        }
    }
