    public void Main(string[] args)
    {
    	
    	try
    	{	        
    		 var t =  GetAPI();
    	     t.Wait();
             Console.WriteLine(t.Result);	
    	}
    	catch (Exception ex)
    	{
    		 Console.WriteLine(ex.Message);	 
    	}
          
    }
    
    public static async Task<string> GetAPI()
    {
       using (HttpClient client = new HttpClient())
       {
          var response = await client.GetAsync("https://www.google.com/"); 
          string content = await response.Content.ReadAsStringAsync(); 
      
         return content;
       }
    }
