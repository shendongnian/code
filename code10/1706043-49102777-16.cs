    internal class SketchDetailPageViewModel : INotifyPropertyChanged
    {
        private string _imgContent;
        public string ImageUri
        {
            get { return _imgContent; }
            set
            {
                _imgContent = value;
                OnPropertyChanged(nameof(ImageUri));
            }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
