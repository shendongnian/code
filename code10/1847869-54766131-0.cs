    public static bool IsYourLoginStillTrue(string userId, string sid)
    {
        CapWorxQuikCapContext context = new CapWorxQuikCapContext();
    
        IEnumerable<Logins> logins = (from i in context.Logins
                                        where i.LoggedIn == true && 
                                        i.UserId == userId && i.SessionId == sid
                                        select i).AsEnumerable();
        return logins.Any();
    }
    
    public static bool IsUserLoggedOnElsewhere(string userId, string sid)
    {
        CapWorxQuikCapContext context = new CapWorxQuikCapContext();
    
        IEnumerable<Logins> logins = (from i in context.Logins
                                        where i.LoggedIn == true && 
                                        i.UserId == userId && i.SessionId != sid
                                        select i).AsEnumerable();
        return logins.Any();
    }
    
    public static void LogEveryoneElseOut(string userId, string sid)
    {
        CapWorxQuikCapContext context = new CapWorxQuikCapContext();
    
        IEnumerable<Logins> logins = (from i in context.Logins 
                                        where i.LoggedIn == true && 
                                        i.UserId == userId && 
                                        i.SessionId != sid // need to filter by user ID
                                        select i).AsEnumerable();
            
        foreach (Logins item in logins)
        {
            item.LoggedIn = false;
        }
            
        context.SaveChanges();
    }
