        protected void OnPropertyChanged(
            [System.Runtime.CompilerServices.CallerMemberName] string propertyName = "")
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
                    OnPropertyChanged();
                }
            }
        }
