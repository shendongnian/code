    public class MyClass : INotifyPropertyChanged
    {
        public bool IsEverythingLoaded
        {
            get { return _isEverythingLoaded; }
            set
            {
                _isEverythingLoaded = value;
                OnPropertyChanged("IsEverythingLoaded");
            }
        }
        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
           PropertyChangedEventHandler handler = PropertyChanged;
           if (handler != null)
               handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
