    public static UserForm UserForm
    {
        get
        {
            if (_userForm == null)
            {
                lock (_lock)
                {
                    _userForm = new UserForm();
                }
            }
            return _userForm;
        }
    }
    private static UserForm _userForm;
