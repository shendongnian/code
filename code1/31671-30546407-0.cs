        public void Execute()
        {
            // Do your task here
            // if task successful, assign true to CloseDialog
            CloseDialog = true;
        }
        private bool _closeDialog;
        public bool CloseDialog
        {
            get { return _closeDialog; }
            set { _closeDialog = value; OnPropertyChanged(); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName]string property = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }   
