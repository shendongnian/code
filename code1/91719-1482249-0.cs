    [CheckArticleExistence]
    public ActionResult Tags(int articleId)
    {
    	...
    }
    
    ...
    
    public class CheckArticleExistenceAttribute : AuthorizeAttribute
    {
    	private int articleId;
    
    	public override void OnAuthorization(AuthorizationContext filterContext)
    	{
    
    		this.articleId = int.Parse(filterContext.RouteData.Values["id"].ToString());
    
    		if (!Article.Exists(articleId))
    		{
    			...
    		}
    	}
    }
