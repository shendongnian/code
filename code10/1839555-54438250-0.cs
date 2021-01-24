    var limit = 4;
	var results = playerSortedList
		// Combine all the users in the lists into a single list
		.SelectMany(l => l) 
		// .SelectMany(l => l.OrderBy(x=>x.Handicap)) // use this in case it is needed to reorder the users within each sub list.
		
		// Use index of the users within the list to create bucket numbers.
		.Select((user, idx) => new { User = user, Bucket = (idx / limit) })
		
		// Group the users using the bucket numbers.
		.GroupBy(x => x.Bucket)
		
		// Make the whole thing a List<List<User>> again.
		.Select(x=>x.Select(bucket => bucket.User).ToList())
		.ToList();
