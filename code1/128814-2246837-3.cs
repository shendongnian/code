    public class MyClass : INotifyPropertyChanged
    {
        private string imageFullPath;
        protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, e);
        }
        protected void OnPropertyChanged(string propertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }
        public string ImageFullPath
        {
            get { return imageFullPath; }
            set
            {
                if (value != imageFullPath)
                {
                    imageFullPath = value;
                    OnPropertyChanged("ImageFullPath");
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
