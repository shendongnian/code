    public void Update(User users // this is your object`enter code here)
    {
    	using(_db)
    	{
    		User user= db.User.Find(users.id);
    		user.Role_id = users.Role_id; // this is what you want to change.
    		_db.Entry(Role).State = EntityState.Unchanged;
    		_db.SaveChanges();
    	}
    }
