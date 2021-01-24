    if(IsValidJson(response)){
    	var wmr = deserializer.Deserialize<WallMartData>(response);
    }
 
    
    private static bool IsValidJson(string strInput)
    {
        try
    	{
    		JToken.Parse(strInput);
    		return true;
    	}
    	catch (JsonReaderException jex)
    	{
    		return false;
    	}
    	catch (Exception ex) 
    	{
    		return false;
    	}
    }
