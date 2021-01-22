    private string m_loginName;
    public string Login_Name 
    { 
        get 
        { 
            return m_loginName; 
        } 
        set 
        {
           m_loginName = !string.IsNullOrEmpty(value) ? value.Replace("'", "''") : value;
        } 
    }
