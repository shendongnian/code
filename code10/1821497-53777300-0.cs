    var query = context.Movies
    	.Include(c => c.ProducerName)
    	.ThenInclude(c => c.Movies)
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
    	});
    
    var moviesWithProducers = query.ToList();
