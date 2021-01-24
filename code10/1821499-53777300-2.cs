    // use .Include and .ThenInclude when returning your entities
    var returningEntities = context.Movies
                                     .Include(p => p.ProducerName)
                                     .ThenInclude(m => m.Movies).ToList();
    
    // No need for Include when use projection
    var returningAnonymousObject = context.Movies
    	.Select(a => new
    	{
    		id = a.Id,
    		name = a.Name,
    		producer = new
    		{
    			id = a.ProducerName.Id,
    			name = a.ProducerName.Name,
    			movies = a.ProducerName.Movies.Select(m => new
    			{
    				id = m.Id,
    				name = m.Name
    			})
    		}
    	}).ToList();
