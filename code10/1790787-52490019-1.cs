    public User(string username)
        {
    
            objsettings = new UserSettings();
            objsettings.nameuser = username;
            DataContext = objsettings; 
            InitializeComponent();
            Console.WriteLine("objsettings.username1: " + objsettings.nameuser);
        }
