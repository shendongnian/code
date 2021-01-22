    public static bool CheckImageExistance(string url)
    		{
    			try
    			{
    				HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest; 
    				request.Method = "HEAD";       
    						
    				request.Credentials = CredentialCache.DefaultCredentials;
    			
    				HttpWebResponse response = request.GetResponse() as HttpWebResponse; 
    				response.Close();
    				return (response.StatusCode == HttpStatusCode.OK);
    			}
    			catch (Exception ex)
    			{
    				return false;
    			}
