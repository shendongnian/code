    class YourType : INotifyPropertyChanged
    {
        private string _theString;
        public string TheString
        {
            get { return _theString; }
            set { _theString = value; NotifyPropertyChanged(); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
