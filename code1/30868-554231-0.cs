    class Person : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged: Shared bit
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }
        #endregion
        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (_firstName == value)
                    return;
                _firstName = value;
                OnPropertyChanged(new PropertyChangedEventArgs("FirstName"));
            }
        }
        // Ditto for other properties
    }
