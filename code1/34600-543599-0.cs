    public class CommonClass : IEquatable<CommonClass>
    {
    	// needed for Distinct()
    	public override int GetHashCode() 
    	{
    		return base.GetHashCode();
    	}
    
    	public bool Equals(CommonClass other)
    	{
    		if (other == null) return false;
    		return [equality test];
    	}
    }
