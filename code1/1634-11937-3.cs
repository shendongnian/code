    using System.Web.Mvc;
    namespace MvcApplication1.Controllers
    {
    	public class PageController : Controller
    	{
    		public void Index()
    		{
    			Response.Write("Page.aspx content.");
    		}
    	}
    }
