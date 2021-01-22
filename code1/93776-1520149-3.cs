        public bool HasChanged { get; set; }
        private void FirePropertyChanged(string s)
        {
            HasChanged = true;
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(s));
            }
        }
