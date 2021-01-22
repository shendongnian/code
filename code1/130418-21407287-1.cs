     private string selectedTitle;
        public string SelectedTitle
        {
            get { return selectedTitle; }
            set
            {
                SetProperty(ref selectedTitle, value);
            }
        }
        public RelayCommand TitleCommand
        {
            get
            {
                return new RelayCommand((p) =>
                {
                    selectedTitle = (string)p;
                });
            }
        }
