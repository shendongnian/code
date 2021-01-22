    public void Save(User user)
    {
       
        if (!DataContext.Users.Contains(user))
        {
            user.Id = Guid.NewGuid();
            user.CreatedDate = DateTime.Now;
            user.Disabled = false;
            user.OrganizationId = DEFAULT_ORG; // make the foreign key connection just
                                               // via a GUID, not by assigning an
                                               // Organization object
            DataContext.Users.InsertOnSubmit(user);
        }
        else
        {
            var UserDB = DataContext.Users.FirstOrDefault(db => db.id == user.id); //Costs an extra call but its worth it if oyu have 400 columns!
            DataContext.Users.Attach(user, userDB); //Just maps all the changes on the flu
        }
        DataContext.SubmitChanges();
    }
