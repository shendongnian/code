    public class MyClass : INotifyPropertyChanged
    {
        private string _StringItem;
        public string StringItem
        {
            get
            {
                return _StringItem;
            }
            set
            {
                _StringItem = value;
                OnPropertyChanged(nameof(StringItem));
            }
        }
        private bool _BoolItem;
        public bool BoolItem
        {
            get
            {
                return _BoolItem;
            }
            set
            {
                _BoolItem = value;
                OnPropertyChanged(nameof(BoolItem));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
