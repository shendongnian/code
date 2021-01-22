    public class MyWSProxy : HttpWebClientProtocol
    {
    	protected override WebResponse GetWebResponse(WebRequest request)
    	{
    		System.Net.WebResponse wr = base.GetWebResponse(request);
    		
    		// read a response header
    		object val = wr.Headers["key"];
	    
    		return wr;
    	}
    }
