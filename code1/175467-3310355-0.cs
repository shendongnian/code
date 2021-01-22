    private String _password;
    private String Password
    {
        get
        {
            if (_password == null)
            {
                _password = CallExpensiveOperation();
            }
            return _password;
        }
    }
