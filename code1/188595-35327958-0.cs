    public class Program
    {
    	public static void Main()
    	{
    		int i = 100;
		
    		Console.WriteLine("Int:               " + i);
		
	    	// Default base definition. By moving chars around in this string, we can further prevent
	    	// users from guessing identifiers.
	    	var baseDefinition = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
	    	//var baseDefinition = "WBUR17GHO8FLZIA059M4TESD2VCNQKXPJ63Y"; // scrambled to minimize guessability
		
	    	// Convert base10 to baseK
	    	var newId = ConvertToBaseK(i, baseDefinition);
	    	Console.WriteLine(string.Format("To base{0} (short): {1}", baseDefinition.Length, newId));
		
	    	// Convert baseK to base10
	    	var convertedInt2 = ConvertToBase10(newId, baseDefinition);
	    	Console.WriteLine(string.Format("Converted back:    {0}", convertedInt2));
	    }
	
	    public static string ConvertToBaseK(int val, string baseDef)
        {
            string result = string.Empty;
            int targetBase = baseDef.Length;
            do
            {
	    		result = baseDef[val % targetBase] + result;
                val = val / targetBase;
            } 
            while (val > 0);
            return result;
        }
	
	    public static int ConvertToBase10(string str, string baseDef)
	    {
		    double result = 0;
		    for (int idx = 0; idx < str.Length; idx++)
		    {
			    var idxOfChar = baseDef.IndexOf(str[idx]);
			    result += idxOfChar * System.Math.Pow(baseDef.Length, (str.Length-1) - idx);
		    }
		
		    return (int)result;
	    }
    }
