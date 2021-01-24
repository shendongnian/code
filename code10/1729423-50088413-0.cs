    usin System.Web.Mvc
    namespace Views.Infrastructure{
    public class CustomrazorViewEngine : RazorViewEngin{
    	public CustomrazorViewEngine(){
    		ViewLocationFormats=new string[]{
    			"~/Views/{1}/{0}.cshtml",
    			"~/Views/Common/{0}.cshtml"
    			};
    		}
    	}
    }
