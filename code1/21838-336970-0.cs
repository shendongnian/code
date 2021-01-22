    public class Example<TValue> where TValue: IComparable
    {
        private TValue _value;
        public TValue Value
        {
            get { return _value; }
            set
            {
    
                if (_value.CompareTo(value) != 0)
                {
                    _value = value;
                    OnPropertyChanged("Value");
                }
            }
        }
    }
