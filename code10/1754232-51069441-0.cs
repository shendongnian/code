    public class A<T> where T : struct
    {
    	public T property;
    	public A()
    	{
    		if(typeof(T) != typeof(int) || typeof(T) != typeof(double))
    		{
    			throw new InvalidConstraintException("Only int or double is supported");
    		}
    	}
    }
