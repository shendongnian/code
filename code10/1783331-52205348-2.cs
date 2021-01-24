    public class HomeController : Controller
    {
    	private List<SelectListItem> items = new List<SelectListItem>()
    	{
    		new SelectListItem() { Text = "Zero", Value = "0"},
    		new SelectListItem() { Text = "One", Value = "1"},
    		new SelectListItem() { Text = "Two", Value = "2"}
    	};
    
    	public ActionResult Index()
    	{
    		ViewBag.Items = items;
    		return View(new Boo() { Id = 1, Name = "Boo name"});
    	}
    
    
    }
    
    public class Boo
    {
    	public int Id { get; set; }
    	public string Name { get; set; }
    }
    
    the view:
    @model WebApi.Controllers.Boo    
    @Html.DropDownListFor(x=>x.Id, (IEnumerable<SelectListItem>) ViewBag.Items)
