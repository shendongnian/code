    public void SaveNewUser(string username, string password)
    {
        string salt = GetSalt();
        string hashedPassword = HashPassword(password, salt, 10000);
        // Go save the hashed password in the DB
        SavePasswordInDatabase(username, hashedPassword);
    }
    public bool AuthenticateLogin(string username, string password)
    {
         string salt = GetSalt();
         string hashedPassword = HashPassword(password, salt, 10000);
         
         // Get the saved Password from database somehow
         string savedPassword = GetSavedPasswordFromDB(string username);
         if(hashedPassword.Equals(savedPassword))
         {
              return true;
         }
         return false;
    }
