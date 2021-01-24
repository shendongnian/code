    public string UserUpdateProperty
    {
        get
        {
            return userUpdate;
        }
        set
        {
            userUpdate = value;
            UpdateUser.text = userUpdate;
        }
    }
