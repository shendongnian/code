    // TEST CODE
    // examplary input:
    // string propertyString = "customerNo";
	string propertyString = "customerName";
    public class IObjectWithProperties
    {
    	public int CustomerNo { get; set; } = 123;
    	public string CustomerName { get; set; } = "Diego";
    }
    
    public class ICustomer
    {
    	public object MyProperty { get; set; }
    }
    
    public IEnumerable<ICustomer> DoSomething(Expression<Func<IObjectWithProperties, object>> express)
    {
    	return new List<ICustomer>() { new ICustomer {MyProperty = express.Compile().Invoke(new IObjectWithProperties())}};
    }
