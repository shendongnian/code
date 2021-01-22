        private BindingList<TfsFile> _tfsFiles;
        
        public BindingList<TfsFile> TfsFiles
        {
            get { return _tfsFiles; }
            set
            {
                _tfsFiles = value;
                NotifyPropertyChanged();
            }
        }
