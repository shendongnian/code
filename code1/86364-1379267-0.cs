    //Overload to make it a bit easier!
    public string stepChar(string str)
    {
    	return stepChar(str, str.Length - 1);
    }
    
    public string stepChar(string str, int charPos)
    {
    	//Escape case 
    	if (charPos < 0)
    	{
    		//just prepend with a and return
    		return "a" + str;
    	}
    	else
    	{
    		//To byte array
    		byte[] strBytes = Encoding.ASCII.GetBytes(str);
    		strBytes[charPos]++;
    
    		if (strBytes[charPos] == 91)
    		{
    			//Z -> a, and +1 to the proceeding col
    			strBytes[charPos] = 97;
    			return stepChar(Encoding.ASCII.GetString(strBytes), charPos - 1); 
    		}
    		else
    		{
    			if (strBytes[charPos] == 123)
    			{
    				//z -> A
    				strBytes[charPos] = 65;
    			}
    
    			return Encoding.ASCII.GetString(strBytes);
    		}
    	}
    }
