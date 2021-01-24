    string [] lines = Data.Substring(startIndex, endIndex - startIndex)
                         .Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
	List<User> allUsers = new List<UserQuery.User>();
	
	for (int i = 0; i < lines.Length; i += 4)
	{
		string name = lines[i].Split(':').Last().Trim();
		string ID   = lines[i + 1].Split(':').Last().Trim();
		string Date = lines[i + 2].Split(':').Last().Trim();
		string Job  = lines[i + 3].Split(':').Last().Trim();
		allUsers.Add(new User(name, ID, Date, Job));
	}
	
