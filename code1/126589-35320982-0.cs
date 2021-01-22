    public class MyEmployee
    {
	    public string FirstName { get; set; }
	    public string LastName { get; set; }
	    public string DisplayName {
		get { return FirstName + " " + LastName; }
	        }
    }
