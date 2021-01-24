    public class MyViewModel : INotifyPropertyChanged
    {
        private bool _isImageVisible;
        public bool IsImageVisible
        {
            get { return _isImageVisible; }
            set {
                if (value != _isImageVisible) {
                    _isImageVisible = value;
                    OnPropertyChanged(nameof(ImageVisibility));
                }
            }
        }
        public Visibility ImageVisibility => _isImageVisible
            ? Visibility.Visible
            : Visibility.Hidden; // or Collapsed
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
