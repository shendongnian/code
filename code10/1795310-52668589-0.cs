    class DataObject : INotifyPropertyChanged
    {
        private bool _isOpened;
        public bool IsOpened
        {
            get { return _isOpened; }
            set { _isOpened = value; NotifyPropertyChanged(); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
