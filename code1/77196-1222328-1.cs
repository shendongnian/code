    public class Customer
    {
    	public static IList<Customer> FindCustomers()
    	{
    		//calls DAL and gets a Collection of customers
    		return DAL.GetCustomers();
    	}
    }
