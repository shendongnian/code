    struct user 
    { 
    public user(string Username, string LastName) 
    { 
        _username = Username; 
    } 
    private string _username; 
    public string UserName { 
        get { return _username; } 
    } 
