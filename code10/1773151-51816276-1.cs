    public bool Login(Models.Login user)
    {
        var encryptedGivenPassword = encrypt(user.Password);
        using (var dbContext = new MVCDEMOEntities())
        {
            return dbContext.UserRegisters.Where(u => u.EmailID == user.EmailID)
                                          .Where(u => u.Password == encryptedGivenPassword)
                                          .Any();
        }
     }
