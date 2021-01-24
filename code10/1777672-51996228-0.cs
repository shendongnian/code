    cfg.CreateMap<CustomerDto, Customer>().AfterMap((source, destination) =>
    {
    	var action = IocManager.IocContainer.Resolve<CustomerAction>();
    	action.Process(source, destination);
    }).ReverseMap();
    
    public class CustomerAction : IMappingAction<CustomerDto, Customer>, ISingletonDependency
    {
    	private readonly IObjectMapper _objectMapper;
    
    	public CustomerAction(IObjectMapper objectMapper)
    	{
    		_objectMapper = objectMapper;
    	}
    
    	public void Process(CustomerDto customerDto, Customer customer)
    	{
    
    	}
    }
