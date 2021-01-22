    public class AdminPage : JQueryPage
    {
    	protected override void OnInit(EventArgs e)
    	{
    		//if not an admin - get out
    		if(!CurrentUserIsAdmin()) Response.End();
    			
    		base.OnInit (e);
    	}
    }
    
    public class JQueryPage : System.Web.UI.Page
    {
    	protected override void OnLoad(EventArgs e)
    	{
    		RegisterJQueryScript();
    		base.OnLoad (e);
    	}
    }
    
    //now here's what I REALLY miss in C#
    public class AdminJQueryPage : AdminPage
