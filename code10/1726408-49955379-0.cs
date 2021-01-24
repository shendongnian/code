    public class ViewModel : INotifyPropertyChanged
    {
        private bool _isEnabled;
        public bool IsEnabled
        {
            get
            {
                return _isEnabled;
            }
            set
            {
                if (_isEnabled != value)
                {
                    _isEnabled = value;
                    OnPropertyChanged("IsEnabled");
                }
            }
        }
        #region INotify
        #region PropertyChanged
        ///<summary>
        /// PropertyChanged event handler
        ///</summary>
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
        #region OnPropertyChanged
        ///<summary>
        /// Notify the UI for changes
        ///</summary>
        public void OnPropertyChanged(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName) == false)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
        #endregion
    }
    
