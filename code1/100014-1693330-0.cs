    public void GetUserById(Guid id, UserCallback callback)
    {
        // Lookup user
        if (userFound)
            callback(userEntity);  // or callback.Call(userEntity);
    }
