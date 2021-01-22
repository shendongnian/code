	public class User
	{
		[Trim]
		public string FirstName { get; set; }
	}
	// Then to preform mutation
	var user = new User() {
    	FirstName = " David Glenn	"
	}
	new MutationContext<User>(user).Mutate();
