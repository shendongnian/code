    // UserServices class
    public void Register(User newUser)
    {
      // add custom registration stuff.
      _userRepository.Save(newUser);
    }
    
    // Application code
    User user = UserFactory.CreateNewUser();
    _userServices.Register(user);
    
    // UserFactory
    public User CreateNewUser()
    {
      // all new user, group creation
    }
