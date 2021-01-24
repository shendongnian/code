    class SomeViewModel
    {
        private readonly Context _context;
        public SomeViewModel(Context context)
        {
           _context = context;
        }
        public ICommand LoginCommand => new RelayCommand(LoginAndStuff);
        private void LoginAndStuff(object param)
        {
            // do stuff here
        }
    }
