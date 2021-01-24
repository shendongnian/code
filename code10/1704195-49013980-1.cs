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
                /* split the item (in this case) in half where the character = '-'.. and store
                 the result in an array object called stringSplit */
    			var firstHalf = stringSplit[0].Trim();
                /* I want to get the 1st element of the
                 array (0 based indexing) and then remove all of the white space */
    			var secondHalf = stringSplit[1].Trim(); 
                /* I want to get the 2nd element of
                the array (0 based indexing) and then remove all of the white space */
    			
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
