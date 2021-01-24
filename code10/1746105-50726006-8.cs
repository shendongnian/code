    public interface IResourceRepository
    {
    	string Get(string name);
    }
    
    public class HttpContextResourceRepository : IResourceRepository
    {
    	public string Get(string name)
    	{
    		return HttpContext.GetGlobalResourceObject("MyResources", name).ToString();
    	}
    }
    
    public class MyFormerStaticClass
    {
    	IResourceRepository _resourceRepository;
    	
    	public MyFormerStaticClass(IResourceRepository resourceRepository)
    	{
    		_resourceRepository = resourceRepository;
    	}
    
    	public string GetText(string name)
    	{
    		return _resourceRepository.Get(name);
    	}
    }
