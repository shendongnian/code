    public Account GetAccount()
    {
       var userDefaults = NSUserDefaults.StandardUserDefaults;
       var stringAccount = userDefaults.StringForKey(AccountIdentifier);
       if (!string.IsNullOrEmpty(stringAccount))
       {
          var account = JsonConvert.DeserializeObject<Models.Account>(stringAccount);
          return account;
       }
    
       return null;
    }
