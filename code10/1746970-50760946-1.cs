    private bool IsValidString(string str)
    {
    	//Lowercase the original string 
    	string lower = str.ToLower();
        //split by space. 
    	List<string> parts = lower.Split(' ').ToList();
    
        //Then check if it contains "on" 
    	if (parts.Contains("on"))
    	{
            // get rid of the disturbing influence of "on"
    		parts.Remove("on");
            //and furthermore check if the rest contains at least on further letter. This allows for numbers to appear
    		if (parts.Any(x => x.ToCharArray().Any(y=> char.IsLetter(y))))
    		{
    			return false;
    		}
            // CHECK here for the date format
    		return true; // here only "on2 exists in the string as a word
    	}
    	else // if no "on" then it is false anyway
    	{
    		return false;
    	}	
    }
