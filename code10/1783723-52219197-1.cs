     private static UserDetails _currentUser = null;
     public static UserDetails CurrentUser
     {
        get
        {
           if (_currentUser == null)
           {
             string data = AppSettings.GetValueOrDefault(nameof(CurrentUser), string.Empty);
             if (data != null)
                _currentUser = JsonConvert.DeserializeObject<LoginResponse>(data);
           }
           return _currentUser;
        }
        set
        {
            string data = JsonConvert.SerializeObject(value);
            AppSettings.AddOrUpdateValue("CurrentUser", data);
            _currentUser = value;
        }
    }
