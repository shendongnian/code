    string sql = "SELECT MenuText FROM tblMenuItems WHERE MenuItemID = @MenuItemID";
    
    Database db = DatabaseFactory.CreateDatabase();
    using(DbCommand cmd = db.GetSqlStringCommand(sql))
    {
    	db.AddInParameter(cmd, "MenuItemID", DbType.Int32, menuItemID);
    
    	using(IDataReader dr = db.ExecuteReader(cmd))
    	{
    		while(dr.Read())
    		{
    			return dr["MenuText"].ToString();
    		}
    		return null;
    	}
    }
