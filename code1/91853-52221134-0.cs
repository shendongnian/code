        private ICommand _passwordCommand;
        public ICommand PasswordCommand
        {
            get {
                if (_passwordCommand == null) {
                    _passwordCommand = new RelayCommand<object>(PasswordClick);
                }
                return _passwordCommand;
            }
        }
        public YourViewModel()
        {
        }
        private void PasswordClick(object p)
        {
            var password = p as PasswordBox;
            Console.WriteLine("Password is: {0}", password.Password);
        }
    }
