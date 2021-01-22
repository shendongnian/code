    public class Customer
    {
    	public static ICollection<Customer> FindCustomers()
    	{
    		Collection<Customer> customers = new Collection<Customer>();
    		
    		foreach (CustomerDTO dto in DAL.GetCustomers())
    			customers.Add(new Customer(dto));  // Do what you need to to create the customer
    		
    		return customers;
    	}
    }
