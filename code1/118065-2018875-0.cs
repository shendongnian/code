    if (string.IsNullOrEmpty(Properties.Settings.Default.UserName))
    {
       string name;
       string password;
       //ask for name and password, replace with your code
       AskForUserandPassword(out name, out password);
       Properties.Settings.Default.UserName=name;
       Properties.Settings.Default.Password=password;
       Properties.Settings.Default.Save()
    }
