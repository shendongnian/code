    public class Program
    {
    	public static void Main()
    	{
    		var lstOfStrings = new List<string>();
    		string stringOne = "123456 - Hello World 1!";
    		string stringTwo = "7891011 - Hello World 2!";
    		
    		lstOfStrings.Add(stringOne);
    		lstOfStrings.Add(stringTwo);
    		
    		foreach(var item in lstOfStrings)
    		{
    			var	stringSplit = item.Split('-');
    			var firstHalf = stringSplit[0].Trim();
    			var secondHalf = stringSplit[1].Trim();
    			
    			Console.WriteLine(firstHalf);
    			Console.WriteLine(secondHalf);
    		}
    		
    	}
    	
    }
    // Output:
    
    // 123456
    // Hello World 1!
    // 7891011
    // Hello World 2!
