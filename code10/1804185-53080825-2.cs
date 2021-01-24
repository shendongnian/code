    var data = new[]
    {
    	new { Id = (object)DBNull.Value },
    	new { Id = (object)DBNull.Value }
    };
    var query = data.OrderBy(e => e.Id);
    
    query.ToList(); // Success
    
    data[1] = new { Id = (object)"whatever" };
    query.ToList(); // Fail
