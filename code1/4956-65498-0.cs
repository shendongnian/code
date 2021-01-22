    public class Class<T> where T : IComparable
    {
    	public T Value { get; set; }
    	public void MyMethod(T val)
    	{
    		if (Value == val)
    			return;
    	}
    }
