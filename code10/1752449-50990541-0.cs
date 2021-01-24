    public abstract class MyClass
    {
    	public abstract int GetHashCodeInternal();
    	
    	public override int GetHashCode()
    	{
    		return GetHashCodeInternal();
    	}
    }
