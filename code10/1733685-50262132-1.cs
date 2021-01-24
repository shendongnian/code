    public class ViewLocationExpander : IViewLocationExpander
    {
    
       public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
    	{
    		// {1} is Controller, {0} is View Name
    		return new [] 
    		{
    			"/Features/{1}/Views/{0}.cshtml", // Finds the Customer View folders
    			"/Features/{1}/{0}.cshtml", // finds the Home views.. they are in root of the folder.. so no need for Views
    			"/Features/Shared/{0}.cshtml" // Layouts
    		};
    	}
    
    	public void PopulateValues(ViewLocationExpanderContext context)
    	{
    
    	}
    }
