    void Main()
    {
    	var test = new Test();
    	test.testMethod();
    }
    
    public static class ListClass<T>
    {
    	public static bool getValues()
    	{
    		return true;
    	}
    }
    
    public class X { public int a; public int b; }
    
    public class Y { public string s; public float f; }
    
    class Test
    {
    	List<Type> listType = new List<Type>();
    
    	public Test()
    	{
    		listType.Add(typeof(X));
    		listType.Add(typeof(Y));
    	}
    
    	public void testMethod()
    	{
    		Console.WriteLine(ListClass<X>.getValues());
    		Console.WriteLine(ListClass<Y>.getValues());
    	}
    }
