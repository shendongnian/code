    // Data validation
    public class IntWrapper
    {
        private int _value;
        public int Value
        {
            get { return _value; }
            set
            {
                if (value < 0) { throw new Exception("Value must be >= 0"); }
                _value = value;
            }
        }
    }
