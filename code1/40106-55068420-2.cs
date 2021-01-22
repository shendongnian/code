    public  class Seasons : ConstantStringsBase
    {
    	// ... same
    }
    
    public  class ConstantStringsBase
    {
    	public static bool IsValid(string propertyName)
    	{		
    		return MethodBase.GetCurrentMethod().DeclaringType.GetProperty(propertyName) != null;
    	}
    }
