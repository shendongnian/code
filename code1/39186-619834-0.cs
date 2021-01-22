    using System;
    using System.Web.UI;
    using System.Threading;
    
    public partial class _Default : Page
    {
    	protected override void OnLoad(EventArgs e)
    	{
    		base.OnLoad(e);
    
    		Response.Write("<h1>please wait...</h1>");
    		Response.Flush();
    
            // simulate load time
    		Thread.Sleep(2000);
    
    		Response.Write("<h1>finished</h1>");
    	}
    }
