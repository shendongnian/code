    // And for the love of all thins neat and tidy in this world
    // start methods with a capital letter :)
    public tblUserData GetUserData(string Id, DateTime loggedIn)
    {
       using (UsersEntities entity = new UsersEntities())
       {
          return entity.tblUserDetails
                       .FirstOrDefault(x => x.Ownerid == Id && x.LoggedIn == loggedIn);
       }
    
    }
