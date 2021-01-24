    [HttpPost]
    public User Register([FromBody]User user)
    {
        if (db.Users.Any(x => x.Email == user.Email))
            throw new Exception("Username \"" + user.Email + "\" is already taken");
        user.Email  = "this is the Email from anywhere";
        user.AID = "This is your Aid Value";
        db.Users.Add(user);
        db.SaveChanges();
         
         //If you want to save Address
       AddressEntity adr = new AddressEntity()
        adr.address = "This is your new address";
        db.Address.Add(adr);
        db.SaveChanges();
        return user;
    }
