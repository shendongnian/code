    public static class Ext {
    	public static bool IsOverloads(this Type type,string methodName)
    	{
    		return IsOverloads(type, methodName, BindingFlags.Public | BindingFlags.Instance);
    	}
    	
    	public static bool IsOverloads(this Type type, 
    								   string methodName, 
    								   BindingFlags flags)
    	{
    		var info = type.GetMethods(flags);
    		return info.Where(o1 => o1.Name == methodName).Count() > 1;
    	}
    }
    
    public class Program
    {        
    	public void Test() { }  
    	public void Test(int a) { }
    	public void TestNo(int a) { }
    	
    	public static void Main()
    	{  
    
    		Console.WriteLine(typeof(Program).IsOverloads("Test")); //True
    		
    		Console.WriteLine(typeof(Program).IsOverloads("TestNo")); //false
    	}
    }
