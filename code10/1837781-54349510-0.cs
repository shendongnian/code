    //Both these calling examples are fine.
    Address a = new Address("Peter", "New york");
    Address b = new Address("Peter", "New york", "some parameter");
    public class Address
    {
	    public Address(string name, string city, string parameter1 = null)
	    {
		    Name = name;
		    City = city;
            Parameter1 = parameter1;
    	}
    
    	public string Name{ get; set; }
    	public string City{ get; set; }
    	public string Parameter1{ get; set; }
    }
