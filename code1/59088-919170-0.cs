    UsernameStatus result = CheckUsernameStatus(username);
    if(result == UsernameStatus.Available)
    {
        CreateUserAccount(username);
    }
    else
    {
        //update UI with appropriate message
    }
    enum UsernameStatus
    {
        Available=1,
        Taken=2,
        IllegalCharacters=3
    }
