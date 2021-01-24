    public void LoginButton()
    {
      bool check = Services.Login.IsValid(Login, Password, context);
      if(check) //if login is OK, check == true
      {
        _eventAggregator.PublishOnUIThread(new OnLoginAttemptMessage
        {
          UserName = Login,
          IsLoginSuccessful = check;
        });
        TryClose();
       }
     }
