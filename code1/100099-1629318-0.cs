    public class Item : INotifyPropertyChanged
    {
        // ...
    
        private bool _isUpdated;
        public bool IsUpdated
        {
            get{ return _isUpdated; }
            set {
                    _isUpdated= value;
                    RaisePropertyChanged("IsUpdated");
                }
        }
        // ...
        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            if(PopertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        // ...
    }
