    using System.Net;
    
    public class MyClass {
    	static public bool URLExists (string url) {
    		bool result = true;
    		
    		WebRequest webRequest = WebRequest.Create(url);
    		webRequest.Timeout = 1200; // miliseconds
    		webRequest.Method = "HEAD";
    		
    		try {
    			webRequest.GetResponse();
    			Debug.Log(url +" exists!");
    		} catch (WebException webException) {
    			result = false;
    			Debug.Log(url +" doesn't exist: "+ webException.Message);
    		}
    		
    		return result;
    	}
    }
