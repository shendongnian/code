    public class Program
    {
    	public static void Main()
    	{
    		var customers = new List<Customer> 
    		{
    			new Customer("a", "c", "b"),
    			new Customer("b", "a", "c"),
    			new Customer("c", "b", "a"),
    		};
            // A: uses Customer.CompareTo    		
    		customers.Sort();
            // B: uses a lambda
    		customers.Sort((x, y) => x.Last.CompareTo(y.Last));
    	
            // C: uses a customer comparer
        	customers.Sort(new MiddleNameComparer());
    	}
    }
