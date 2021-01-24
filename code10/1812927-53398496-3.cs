    public class Person  // Version 3
    {
    	public string FirstName { get; set; }
    	public string LastName { get; set; }
    	public DateTime? Birthday { get; set; }
    
    	// This property is here to support transitioning from Version 2 to Version 3
    	[JsonProperty]
    	private string Name
    	{
    		set
    		{
    			if (value != null)
    			{
    				string[] parts = value.Trim().Split(' ');
    				if (parts.Length > 0) FirstName = parts[0];
    				if (parts.Length > 1) LastName = parts[1];
    			}
    		}
    	}
    }
