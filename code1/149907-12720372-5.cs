    public virtual ActionResult UpdateLastActivityDate(string userName)
    {
        User user = Database.Users.Single(u => u.UserName == userName);
    
        user.LastActivityDate = DateTime.Now;
    
        Database.Entry(user).State = EntityState.Modified;
    
        Database.SaveChanges();
    
        return new EmptyResult();
    }
