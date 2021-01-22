    public class XmlSiteMapProvider : System.Web.XmlSiteMapProvider
    {
    	public override bool IsAccessibleToUser(HttpContext context, SiteMapNode node)
    	{
    		var roles = node.Roles.OfType<string>();
    		if (roles.Contains("*") || (roles.Count(r => context.User.IsInRole(r)) > 0))
    		{
    			return true;
    		}
    		else
    		{
    			throw new InsufficientRightsException();
    		}
    	}
    }
