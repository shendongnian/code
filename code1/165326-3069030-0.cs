    bool ValidateLogin(DataClasses1DataContext context, string user, string password)
    {
       byte[] providedPasswordHash = hashPassword(password);
       byte[] expectedPasswordHash = context.Users.Where(u => u.Name == user).Single().PasswordHash;
       if (providedPasswordHash.Length != expectedPasswordHash.Length)
          return false;
       for(int i = 0; i < providedPasswordHash.Length; i++)
          if (providedPasswordHash[i] != expectedPasswordHash[i])
             return false;
       return true;
    }
    byte[] hashPassword(string password)
    {
       System.Security.Cryptography.SHA1CryptoServiceProvider hasher =
          new System.Security.Cryptography.SHA1CryptoServiceProvider();
       return hasher.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
    }
