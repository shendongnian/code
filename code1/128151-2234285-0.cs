    public class GenerateRandomImagePath : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName);
        }
        private string _imageFullPath;
        public string ImageFullPath
        {
            get { return _imageFullPath; }
            set
            {
                _imageFullPath = value;
                OnPropertyChanged("ImageFullPath");
            }
        }
    }
