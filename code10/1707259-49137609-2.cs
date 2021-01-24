    public UserResponse GetUsers() 
    {
        var users = _service.GetUsers()
        var model = new UserResponse(users);
        return model;
    }
