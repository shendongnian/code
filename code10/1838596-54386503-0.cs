    public static class ModelStateHelper
    {
    	public static IEnumerable Errors(this ModelStateDictionary modelState)
    	{
    		if (!modelState.IsValid)
    		{
    			return modelState.Errors();
    		}
    
    		return null;
    	}
    }
