	List<User> allUsers = new List<UserQuery.User>();
	
	for (int i = 0; i < lines.Length; i+=4)
	{
		string name = lines[i].Split(':').Last();
		string ID   = lines[i + 1].Split(':').Last();
		string Date = lines[i + 2].Split(':').Last();
		string Job  = lines[i + 3].Split(':').Last();
		allUsers.Add(new User(name, ID, Date, Job));
	}
