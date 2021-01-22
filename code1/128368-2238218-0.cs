    using (TheDataContext dc = new TheDataContext)
    {
      //pull all users into memory, not recommended for large tables.
      List<User> users = dc.Users.ToList();
    
      foreach(User theUser in users)
      {
        theUser.ShowData = false;
      }
      //send all these property changes back to the database.
      dc.SubmitChanges();
    }
