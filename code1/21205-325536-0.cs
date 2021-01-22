    public class HomeController : Controller
    {
    	public ActionResult Index()
    	{
    		this.ViewData.Model = new MyObject
    		{
    			Name = "Timmy",
    			FavColor = "Blue",
    		};
    
    		return View();
    	}
    
    	public class MyObject
    	{
    		public string Name { get; set; }
    
    		public string FavColor { get; set; }
    	}
    }
