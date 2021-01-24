    client.Bulk(b =>
    	{
    		foreach (var entity in col.ToList())
    			b
    				.Update<Entity>(u =>
    					u.DocAsUpsert(true)
    						.Id(entity.Id)
    						.Doc(entity)
    						.Index(IndexName));
    		return b;
    	}
    )
