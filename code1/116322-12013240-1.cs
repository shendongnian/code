    using System.Net;
    
    public class MyClass {
    	static public bool URLExists (string url) {
    		bool result = false;
    		
    		WebRequest webRequest = WebRequest.Create(url);
    		webRequest.Timeout = 1200; // miliseconds
    		webRequest.Method = "HEAD";
    		HttpWebResponse response = null;
    		try {
    			response = (HttpWebResponse)webRequest.GetResponse();
    			result = true;
    		} catch (WebException webException) {
    			Debug.Log(url +" doesn't exist: "+ webException.Message);
    		} finally {
    			if (response != null) {
    				response.Close();
    			}
    		}
    		
    		return result;
    	}
    }
