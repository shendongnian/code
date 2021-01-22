    public class MyWebServiceDiagnosticsModule : IHttpModule
    {
    	public MyWebServiceDiagnosticsModule ()
    	{
    	}
    	void IHttpModule.Init(HttpApplication context)
    	{
    		context.BeginRequest += new EventHandler(BeginRequest);
    	}
    	private void BeginRequest(object sender, EventArgs e)
    	{
    		HttpContext ctx = HttpContext.Current;
    		string url = ctx.Request.Url.ToString().ToLower();
    		if (url.Contains("mywebservice.asmx"))
    		{
    		    LogMethodCall(url); // parse URL and write to DB
    		}
    	}
    }
