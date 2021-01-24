    public ActionResult Login(UserLogin login)
    {
      var v = dc.Users.Where(a => a.UserEmailAddress == login.UserEmailAddress).FirstOrDefault();
      if(string.Compare(Crypto.Hash(login.UserPassword), v.UserPassword) == 0)
      {
         //do login here
      }
    }
