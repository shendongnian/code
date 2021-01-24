    public class User
    {
    	public string firstname { get; private set;}
    	public string lastname { get; private set;}
    	public string proposedname { get ; private set; }
    	public User(string firstname, string lastname)
    	{
    		this.firstname = firstname;
    		this.lastname = lastname;
            this.proposedname = $"{firstname}.{lastname}".ToLower();
    	}
    }
