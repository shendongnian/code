    public interface ICustomerFactory
    {
    	ICustomer Create(string key);
    }
    public class CustomerFactory : ICustomerFactory
    {
    	private readonly IContainer _container;
    	public CustomerFactory(IContainer container)
    	{
    		_container = container;
    	}
    	public ICustomer Create(string key) => _container.TryGetInstance<ICustomer>(key);
    }
