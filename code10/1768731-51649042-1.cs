    var test = new string[1] { "Test string 1" };
    
    test = AddItemToArray(test, "Test string 2");
    private static string[] AddItemToArray(string[] original, string item)
    {
    	var result = new string[original.Length + 1];
    	
    	for (int i = 0; i < original.Length; i++)
    	{
    		result[i] = original[i];
    	}
    
    	result[result.Length - 1] = item;
    
    	return result;
    }
