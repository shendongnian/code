    /// <summary>
    /// Getting filter Attribute on proxy class
    /// </summary>
    public class FilterInfo
    {
    	private List<IExcuteFilter> _excuteFilters = new List<IExcuteFilter>();
    
    	public FilterInfo(MarshalByRefObject target, MethodInfo method)
    	{
    		//search for class Attribute
    		var classAttr = target.GetType().GetCustomAttributes(typeof(AopBaseAttribute), true);
    		//search for method Attribute
    		var methodAttr = Attribute.GetCustomAttributes(method, typeof(AopBaseAttribute), true);
    
    		var unionAttr = classAttr.Union(methodAttr);
    
    		_excuteFilters.AddRange(unionAttr.OfType<IExcuteFilter>());
    	}
    
    	public IList<IExcuteFilter> ExcuteFilters
    	{
    		get
    		{
    			return _excuteFilters;
    		}
    	}
    }
