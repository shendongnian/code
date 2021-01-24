            private Installers _SelectedInstaller;
        public Installers SelectedInstaller
        {
            get { return _SelectedInstaller; }
            set { _SelectedInstaller = value; OnPropertyChanged(nameof(SelectedInstaller)); }
            private Visibility _IsVisible;
        public Visibility IsVisible
        {
            get { return _IsVisible; }
            set { _IsVisible = value; OnPropertyChanged(nameof(SelectedInstaller.IsDownloaded)); } 
        }
