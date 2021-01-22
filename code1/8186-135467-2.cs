    public class MyRestService: RestService
    {
        [RestMethod(HttpVerb.GET)]
    	public void HelloWorld()
    	{
    	    _context.Current.Response.Write("Hello World");
    		_context.Current.Response.End();
    	}
    }
