    using (var db = new DatabaseContext())
    using (var transaction = db.Database.BeginTransaction())
    {
    	var userType = new USER_TYPE
    	{
    		NAME = "admin"
    	};
    
    	db.USER_TYPES.Add(userType);
    	db.SaveChanges();
    
    	Debug.Assert.IsTrue(userType.ID != 0); // ✔️ will be passed.
    }
