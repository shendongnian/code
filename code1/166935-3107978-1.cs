    public string Login_Name
    {
       get
       {
          return _login_Name;
       }
       set
       {
          _login_Name = value;
          if (!string.IsNullOrEmpty(_login_Name))
          {
             _login_Name = _login_Name.Replace("'", "''");
          }
       }
    }
    private string _login_Name;
