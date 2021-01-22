    using(var pc = new PrincipalContext(ContextType.Domain))
    {
      using(var up = new UserPrincipal(pc))
      {
        up.SamAccountName = username;
        up.EmailAddress = email;
        up.SetPassword(password);
        up.Enabled = true;
        up.ExpirePasswordNow();
        up.Save();
      }
    }
