    private static string _username = null;
    public static string UserName
    {
        get { return _userName; }
        private set
        {
            if (_username == null) _username = value;
        }
    }
