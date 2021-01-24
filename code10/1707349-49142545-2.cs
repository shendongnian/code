    public void UserEdit(int?id //id is your parameter here)
    {
       //This is what you need.
    
        User user= db.User.Find(id);
        user.Role = //this is the new Role if this user
        user.CityId = //city id here
    }
