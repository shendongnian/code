    [HttpPost]
    [Authorize(Roles = "User")]
    public ActionResult Settings(User _users)
    {
        using (MydbEntities db = new MydbEntities())
        {
            string _Email = User.Identity.GetUserId().ToString();
    
            // try to find the existing user in the database
    	    User existing = db.Users.FirstOrDefault(x => x.Email == _Email);
    		
    		if(existing != null)
            {
                // if you *DID* find a user - then update its properties
                existing.BusinessName = _users.BusinessName;
                existing.Address = _users.Address;
                existing.VatNumber = _users.VatNumber;
                existing.PhoneNumber = _users.PhoneNumber;
                existing.IsBusinessUser = _users.IsBusinessUser;
    
                var foo = db.SaveChanges();
            }
        }
    }
