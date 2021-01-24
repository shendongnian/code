    // TEST CODE
    // examplary input:
    // string propertyString = "customerNo";
	string propertyString = "customerName";
    public interface IObjectWithProperties
    {
    	int CustomerNo { get; set; }
    	string CustomerName { get; set; }
    }
    
    public class Customer : IObjectWithProperties
    {	
    	public int CustomerNo { get; set; } = 123;
    	public string CustomerName { get; set; } = "Diego";	
    }
    
    public IEnumerable<Customer> DoSomething(Expression<Func<IObjectWithProperties, object>> express)
    {
    	List<Customer> list = new List<Customer>() 
    	{
    		new Customer() { CustomerNo = 923, CustomerName = "Alex" }, 
    		new Customer() { CustomerNo = 1, CustomerName = "Zed"}
    	};
    		
    	return list.OrderBy(x => express.Compile().Invoke(x)).ToList();
    }
