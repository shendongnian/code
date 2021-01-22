    public bool ValidateApplicationUser(string userName, string password)
    {
      DataClasses1DataContext dc = new DataClasses1DataContext();
      var saltValue = dc.ProvaHs.Where(c => c.UserName == userName).Select(c=>c.Salt).SingleOrDefault();
      if (saltValue == null) return false;
      password = PasswordCrypto.HashEncryptStringWithSalt(passwordTextBox.Password, saltValue.ToString());
      return dc.ProvaHs.Count(c=>c.UserName == userName && c.Password == password) > 0;
    }
