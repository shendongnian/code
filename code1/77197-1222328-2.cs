    public class Customer
    {
    	public static IList<Customer> FindCustomers()
    	{
    		List<Customer> customers = new List<Customer>();
    		
    		foreach (CustomerDTO dto in DAL.GetCustomers())
    			customers.Add(new Customer(dto));  // Do what you need to to create the customer
    		
    		return customers;
    	}
    }
