    var scores = db.Scores.AsQueryable();
    // Optional
    // scores = scores.Where(p => p.CategoryId == categoryId);
    
    var points = scores
    	 .GroupBy(s => s.UserId)
    	 .Select(g => new
    	 {
    		 UserId = g.Key,
    		 Points = g.Sum(s => s.Points),
    	 });
    
    var result = db.Users
    	.Join(points, u => u.UserId, p => p.UserId, (u, p) => new
    	{
    		u.UserId,
    		u.Name,
    		p.Points
    	})
    	.OrderBy(p => p.Points)
    	.ToList();
