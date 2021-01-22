    public UserEntity test(UserEntity userEntityX)
    {
        var userService = new UserService.UserServiceSoapClient();
        return userService.testUser(userEntityX);
    }
