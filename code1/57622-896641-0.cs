    public string GetPassword()
    {
    
    using (OleDbConnection con = new OleDbConnection(database2.conn))
    {
    
    using (OleDbCommand OCom = new OleDbCommand("select user_pasword from tblpasword where id = 1", con))
    {
    	con.Open();
    
    	using (IDataReader Dreader = OCom.ExecuteReader())
    	{
    		if (Dreader.Read())
    		{
    			return Dreader.GetString(0);
    		} else return null;
    	}
    }
    
    }
    
    }
