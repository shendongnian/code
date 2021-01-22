    public class Example<TValue>
    {
        private TValue _value;
        public TValue Value
        {
            get { return _value; }
            set
            {
                if (!object.Equals(_value, value))
                {
                    _value = value;
                    OnPropertyChanged("Value");
                }
            }
        }
    }
