    public async Task<string> GetDataWithRetry(int UserID, int Tries = 1)
    {
    	Exception lastexception = null;
    	
    	for (int trycount=0; trycount < tries; trycount++)
    		try
    		{
    			return await GetData(UserID);
    		}
    		catch (Exception Ex)
    		{
    			lastexception = Ex;
    		}
    		
    	throw lastexception;
    }
    
    public async Task<string> GetData(int UserID)
    {
    	 var Request = new HttpRequestMessage(HttpMethod.Post, "myurlhere");
    	 //Set other request info like headers and payload
    
    
    	 var Response = await WebClient.SendAsync(Request);             
    	 return await Response.Content.ReadAsStringAsync();         
    }
