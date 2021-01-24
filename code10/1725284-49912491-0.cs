	var groupUsers = new List<dynamic>() { 
		new { groupId = 1, userId = 1, name = "a" },
		new { groupId = 1, userId = 1, name = "b" },
		new { groupId = 1, userId = 2, name = "c" }
		};
		
	var result =  groupUsers
		.GroupBy(u => new { u.groupId, u.userId} )
		.Select(g => g.OrderBy(u => u.name).FirstOrDefault());
