        public RelayCommand UpCommand { get; set; }
        public MainWindowViewModel()
        {
              UpCommand = new RelayCommand(UpExecute);
        }
        public User SelectedUser { get; set; }
        private void UpExecute()
        {
            MessageBox.Show($"You Upped {SelectedUser.Title}");
        }
