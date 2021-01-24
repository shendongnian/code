	void Main()
	{
		//create a reference to our user manager
		var userManager = new UserManager();
		
		//run some demos with different search criteria
		SearchAndDisplay(userManager, null, "Anne", "Droid"); //should return true
		SearchAndDisplay(userManager, null, "Anne", "Borgue"); //should return false
		SearchAndDisplay(userManager, null, "Simon", "Borgue"); //should return true
		SearchAndDisplay(userManager, "Two", null, null); //sshould return true
		SearchAndDisplay(userManager, "Four", null, null); //should return false
		SearchAndDisplay(userManager, null, null, null); //should return true (as we've not given any filter criteria, and users do exist)
		SearchAndDisplay(new UserManager(true), null, null, null); //should return true (as we've not given any criteria, but no users exist so there is no match)
	}
	void SearchAndDisplay(UserManager userManager, string searchByUsername, string searchByGivenName, string searchBySurname)
	{
		//build up our query
		Predicate<User> searchCriteria = And<User>(); //`And` with no arguments is simply `true`
		if (!string.IsNullOrEmpty(searchByUsername)) searchCriteria = And<User>(searchCriteria, user => searchByUsername.Equals(user?.Username, StringComparison.InvariantCultureIgnoreCase));
		if (!string.IsNullOrEmpty(searchByGivenName)) searchCriteria = And<User>(searchCriteria, user => searchByGivenName.Equals(user?.GivenName, StringComparison.InvariantCultureIgnoreCase));
		if (!string.IsNullOrEmpty(searchBySurname)) searchCriteria = And<User>(searchCriteria, user => searchBySurname.Equals(user?.Surname, StringComparison.InvariantCultureIgnoreCase));
		
		//search the users using the criteria defined above; NB: The user manager does not need to know anything about our query logic, so our client has lots of flexibility in what queries it can use / is not restricted by the UserManager's implementation
		var result = userManager.UserMatchingCriteriaExists(searchCriteria);
		
		//display some output to show the user what we've done
		Console.WriteLine($"Search Criteria:\n\tUsername: {searchByUsername ?? "not searched"}\n\tGivenName: {searchByGivenName ?? "not searched"}\n\tSurname: {searchBySurname ?? "not searched"}\nFound: {result}");
	}
	///Holds basic user information
	class User 
	{
		public User(){}
		public string Username{get; set;}
		public string GivenName{get; set;}
		public string Surname{get; set;}
	}
	///Holds the collection of users & allows operations against them
	class UserManager 
	{
		readonly IEnumerable<User> users;
		public UserManager(): this(false) {}
		public UserManager(bool noUsers)
		{
			if (noUsers) 
			{
				users = new User[]{};
			}
			else
			{
				users = new User[]
				{
					new User(){Username = "one", GivenName = "Anne", Surname = "Droid"}
					,new User(){Username = "two", GivenName = "Simon", Surname = "Borgue"}
					,new User(){Username = "three", GivenName = "Alex", Surname = "Arnold"}
				};
			}
		}
		public bool UserMatchingCriteriaExists(Predicate<User> criteria)
		{
			return users.Any(user => criteria(user));
		}
	}
	///Allows us to combine predicates
	Predicate<T> And<T>(params Predicate<T>[] predicates)
	{
	    return delegate (T item)
	    {
	        foreach (var predicate in predicates)
	        {
	            if (!predicate(item))
	            {
	                return false;
	            }
	        }
	        return true;
	    };
	}
