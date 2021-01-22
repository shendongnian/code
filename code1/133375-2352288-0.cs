    public static bool HasPassword(string userId)
     {
    
        using(var db = new ProjDataContext())
        {
    
           bool hasPassword = (from p in db.tblSpecUser
                                        where p.UserID == userId
                                        select p.HasPassword).FirstOrDefault();
    
    
            return hasPassword;
        }
    }
