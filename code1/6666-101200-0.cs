    public class CSSLink : System.Web.UI.Control
    {
    
    	protected override void Render(System.Web.UI.HtmlTextWriter writer)
    	{
    
    		if ( ... querystring params == ... )
    			writer.WriteLine("<link href=\"/styles/css1.css\" type=\"text/css\" rel=\"stylesheet\" />")
    		else
    			writer.WriteLine("<link href=\"/styles/css2.css\" type=\"text/css\" rel=\"stylesheet\" />")
    
    	}
    
    }
