    public class Program
    {
    	
    	public static void Main()
    	{
    		var result = Transform("abcde");
    		result.ToList().ForEach(WriteLine);
    	}
    	
    	public static IEnumerable<string> Transform(string str)
    	{
    		foreach (var w in str)
    		{
    			var split = str.Split(w);
    			
    			yield return  split[0] + char.ToUpper(w) + split[1];
    		}
    	}
    }
