    public void UpdateUser(User user)
    {
       db.Entry(user).State = EntityState.Modified;
       db.SaveChanges();
     
    }
