        public class Example<TValue>
        {
            private TValue _value;
            public TValue Value
            {
                get { return _value; }
                set
                {
                    if (_value.GetType().IsClass)
                    {
                        if (!System.Object.ReferenceEquals(_value, value))
                        {
                            _value = value;
                            OnPropertyChanged("Value");
                        }
                    }
                    else
                    {
                        if (!_value.Equals(value))
                        {
                            _value = value;
                            OnPropertyChanged("Value");
                        }
                    }
                }
            }
        }
