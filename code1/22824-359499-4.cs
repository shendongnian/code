    public class EmployeeController : IEmployeeController
    {
    	private readonly IEmployeeDataProvider _provider;
    
    	[InjectionConstructor]
    	public EmployeeController(IEmployeeDataProvider DataProvider)
    	{
    		_provider = DataProvider;
    	}
    }
