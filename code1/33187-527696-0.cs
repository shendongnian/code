        public T Value
        {
            get { return value; }
            set
            {
                try
                {
                    Enum.Parse(typeof(T), value.ToString());
                }
                catch 
                {
                    throw new ArgumentOutOfRangeException("value", value, "Value not defined in enum, " + typeof(T).Name);
                }
                if (!this.value.Equals(value))
                {
                    this.value = value;
                    PropertyChangedEventHandler handler = PropertyChanged;
                    if (handler != null)
                        handler(this, new PropertyChangedEventArgs("Value"));
                }
            }
        }
