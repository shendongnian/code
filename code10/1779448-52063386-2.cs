    class RssUser: INotifyPropertyChanged
    {
        private AppService _log = new AppService();
        string user;
        string pass;
        string company;
        public event PropertyChangedEventHandler PropertyChanged;
       public ICommand LoginCommmand
        {
            get
            {
                return new Command(async () =>
                {
                    await _log.LoginAsync(user, pass, company);
                });
            }
        }
        public string User
        {
            set
            {
                if (user != value)
                {
                    user = value;
                     PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(User)))
                }
            }
            get
            {
                return user;
            }
        }
        // You would also want to similar for pass and company.
    }
