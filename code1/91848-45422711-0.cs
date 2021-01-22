    public string password;
    PasswordChangedCommand = new DelegateCommand<RoutedEventArgs>(PasswordChanged);
  
    Private void PasswordChanged(RoutedEventArgs obj)
    {
        var e = (WatermarkPasswordBox)obj.OriginalSource;
        //or depending or what are you using
        var e = (PasswordBox)obj.OriginalSource;
        password =e.Password;
    }
