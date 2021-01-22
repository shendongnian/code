    public class UnityContainerImplementation : IContainer
    {
    	IUnityContainer container;
    
    	public UnityContainerImplementation(IUnityContainer container)
    	{
    		this.container = container;
    	}
    
    	public void Register<TAbstraction, TImplementation>()
    	{
    		container.Register<TAbstraction, TImplementation>();
    	}
    
    	public void RegisterThis<T>(T instance)
    	{
    		container.RegisterInstance<T>(instance);
    	}
    
    	public T Get<T>()
    	{
    		return container.Resolve<T>();
    	}
    }
