    public class DateTimeWrapper : INotifyPropertyChanged
    {
        private DateTime _dateTime;
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged()
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs("Value"));
        }
        public DateTime Value
        {
            get { return _dateTime; }
            set
            {
                _dateTime = value;
                OnPropertyChanged();
            }
        }
    }
