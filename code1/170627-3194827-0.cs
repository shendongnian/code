    public class Global : System.Web.HttpApplication
    {
    	//...
    
    	protected void Application_EndRequest(object sender, EventArgs e)
    	{
    		if (this.Response.StatusCode == 302) this.Response.RedirectLocation = Relativize(this.Response.RedirectLocation);
    	}
    
    	//...
    }
