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
