        public RelayCommand MyCommand { get; set; }
        public PlayerViewModel()
        {
            MyCommand = new RelayCommand(DoSomething);
        }
        public void DoSomething(object parameter)
        {
            MessageBox.Show("Player Working!");
        }
