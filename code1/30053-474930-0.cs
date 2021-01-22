    void TestUserDBFailure()
    {
        // ***** THIS IS PSEUDO-CODE *******
        //setting up the stage - retrieval of the user info create an exception
        Expect.Call(_userRepository.GetUser(null))
           .IgnoreArguments()
           .Return(new Exception());
    
        // Call that uses the getuser function, see how it reacts
        User selectedUser = _dataLoader.GetUserData("testuser", "password");        
    }
