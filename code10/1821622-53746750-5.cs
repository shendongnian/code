    public void SaveNewUser(string username, string password)
    {
        string salt = GetSalt();
        string hashedPassword = HashPassword(password, salt, 10000);
        // Go save the username, hashed password and salt in the DB
        SaveUserInDatabase(username, hashedPassword, salt);
    }
    public bool AuthenticateLogin(string username, string password)
    {
         // Get the salt saved from the DB for the user somehow
         string salt = GetSaltFromDB(string username);
         string hashedPassword = HashPassword(password, salt, 10000);
         
         // Get the saved Password from database somehow
         string savedPassword = GetSavedPasswordFromDB(string username);
         if(hashedPassword.Equals(savedPassword))
         {
              return true;
         }
         return false;
    }
