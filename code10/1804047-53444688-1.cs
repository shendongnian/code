    public void DeleteUser()
    {
         string userId = User.Identity.GetUserId();
         ApplicationUser LoggedUser = db.Users.Find(userId);
         db.Users.Remove(LoggedUser);
         AdditionalInfo info = db.AdditionalInfo.Find(userId); // Added this
         db.AdditionalInfo.Remove(info); // Added this
       
         db.SaveChanges();
    }
