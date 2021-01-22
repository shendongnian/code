    public class NotifyValue<datatype> : INotifyPropertyChanged 
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        datatype _value;
        public datatype Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Value"));
            }
        }
    }
