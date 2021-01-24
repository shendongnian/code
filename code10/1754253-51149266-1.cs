    public class Program
    {
    	public static void Main()
    	{
    		var a = A.CreateDecimal();
    		a.property = 7;
    	}
    }
    
    public class A<T>
    {
    	public T property;
    	internal A()
    	{
    	}
    }
    
    public static class A
    {
    	public static A<decimal> CreateDecimal() => new A<decimal>();
    	public static A<int> CreateInt() => new A<int>();
    }
