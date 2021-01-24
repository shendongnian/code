    public class StateBusiness
    {
    	public List<SelectListItem> GetStatesForDropdown()
    	{
    		//your code here
    		return new  List<SelectListItem>();
    	}
    	
    }
    
    public class StateController : Controller
    {
    	
    	var state = new StateBusiness();
    	
    	public ActionResult Index()
    	{
    		var states = state.GetStatesForDropdown();
    		ViewBag.states = states;
    		return View();
    	}
    }
    
    public class DistrictController : Controller
    {
    	
    	var state = new StateBusiness();
    	
    	public ActionResult Index()
    	{
    		var states = state.GetStatesForDropdown();
    		ViewBag.states = states;
    		return View();
    	}
    }
