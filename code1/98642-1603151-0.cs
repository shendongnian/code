    public List<User> GetUsers()
    {
        List<User> result = new List<User>();
    
        Database db = new
    	Microsoft.Practices.EnterpriseLibrary.Data.Sql.SqlDatabase(this.connectionString);
        DbCommand cmd = db.GetStoredProcCommand("GetUsers");
    
        using (IDataReader rdr = db.ExecuteReader(cmd))
        {
    	    while (rdr.Read())
    	    {
    	        User user = new User();
    	        FillUser(rdr, user);                   
    	        result.Add(user);
    	    }
        }
        return result;
    
    }
