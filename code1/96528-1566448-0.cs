    public User GetUser(string username)
    {
         try
         {
              return DBLookup.GetUser(username);
         }
         catch (DBLookupException ex)
         {
              // throw exception or handle exception
              return null;
         }
    }
