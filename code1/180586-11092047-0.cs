    class SetupOption<T> : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
        private T _value;
        public T Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(_value, new PropertyChangedEventArgs("Value"));
                }
            }
        }
    }
