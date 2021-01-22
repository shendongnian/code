    EntityConnection conn = new EntityConnection(ConnectionString);
    
    using (TransactionScope ts = new TransactionScope())
    {
    	using (DatabaseEntityModel o = new DatabaseEntityModel(conn))
    	{
    	        var v = (from s in o.Advertiser select s).First();
             	v.AcceptableLength = 1;
    	}
    
    	//-> By commenting out this section, it works
    	using (DatabaseEntityModel o = new DatabaseEntityModel(conn))
    	{
    		//Exception on this next line
    		var v = (from s1 in o.Advertiser select s1).First();
                    v.AcceptableLength = 1;
    	}
    	//->
    
    	ts.Complete();
    }
