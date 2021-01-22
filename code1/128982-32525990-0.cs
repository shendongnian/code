    public class Customer
    {
    	public Customer3(string firstName, string lastName)
    	{
    		FirstName = firstName;
    		LastName = lastName;
    	}
    	public string FirstName { get; }
    	public string LastName { get; }
    	public string Company { get; } = "Microsoft";
    }
    
    var customer = new Customer("Bill", "Gates");
