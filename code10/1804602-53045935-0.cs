	public List<User> getUsersWhoCan...()
	{
		var users = _context
				.Users
				.Include(x => x.Permissions)
				.Take(10000)
				.OrderByDescending(x => x.CreationDate)
				.ToList();
				
		var tempList = new List<User>();
		foreach (var user in users)
		{
			if (CanPerformAction(user))
			{
				tempList.Add(user);
			}
		}
		return tempList;
	}
