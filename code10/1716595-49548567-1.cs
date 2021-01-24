    //StateBusiness.cs
    public class StateBusiness
    {
    	public List<SelectListItem> GetStatesForDropdown()
    	{
    		//your logic here
    		return new  List<SelectListItem>();
    	}
    }
    
    //StateController.cs
    public class StateController : Controller
    {
    	var state = new StateBusiness();
    	
    	public ActionResult Index()
    	{
            //call your code here 
    		var states = state.GetStatesForDropdown();
            //and do whatever you want
    		ViewBag.states = states;
    		return View();
    	}
    }
    
    //DistrictController.cs
    public class DistrictController : Controller
    {
    	var state = new StateBusiness();
    	
    	public ActionResult Index()
    	{
            //call it from here just the same
    		var states = state.GetStatesForDropdown();
    		ViewBag.states = states;
    		return View();
    	}
    }
