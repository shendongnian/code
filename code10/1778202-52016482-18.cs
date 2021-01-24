	var user = _context.Users
	    .Where(u => u.Email == email)
		.Include(u => u.Customer)
		.FirstOrDefault();
		
	if (user != null)
	{
		var groups = _context.CustomerGroups
			.Where(cg => cg.Customer.UserId == user.Customer.UserId)
			.Include(cg => cg.Group)
			.ToArray();
			
		foreach (var group in groups)
		{
			var s = group.Group;
			//do something			
		}
	}
