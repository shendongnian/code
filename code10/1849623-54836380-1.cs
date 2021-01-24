        private GridLength notamWidth;
        
        public GridLength NotamWidth
        {
            get
            {
                return notamWidth;
            }
            set
            {
                notamWidth = value;
                OnPropertyChanged("NotamWidth");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
