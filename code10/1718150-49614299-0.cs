    public sealed class SystemClass
    {
    }
    
    public class CustomClass
    {
    	private SystemClass _systemClass;
    	
    	public CustomClass(SystemClass systemClass)
    	{
    		_systemClass = systemClass;
    	}
    
    	public static explicit operator CustomClass(SystemClass systemClass)
    	{
    		return new CustomClass(systemClass);
    	}
    
    	public static implicit operator SystemClass(CustomClass customClass)
    	{
    		return customClass._systemClass;
    	}
    }
