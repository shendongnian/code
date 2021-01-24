    public class Program
    {
    	public static object f1() {
    		return new {string1 = "a", string2 = "b"};
    	}
    	
    	public static void Main()
    	{
    		var x = f1();
    		var p = x.GetType().GetProperty("string1");
    		string s = (string)p.GetValue(x);
    		Console.WriteLine(s);
    	}	
    	
    }
