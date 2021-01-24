    public class HomeController : Controller
    {
    
    	public ActionResult Index()
    	{
    		return View();
    	}
    
    	[HttpPost]
    	public ActionResult Method1(BooModel model)
    	{
           ...
    	}
    
    	[HttpPost]
    	public ActionResult Method2(BooModel model)
    	{
           ...
    	}
    
    
    }
    
    public class BooModel
    {
    	public int Id { get; set; }
    	public string Name { get; set; }
    }
    
    
    @model WebApi.Controllers.BooModel
    
    @using (Html.BeginForm())
    {
        @Html.TextBoxFor(x=>x.Id)
        @Html.TextBoxFor(x=>x.Name)
    
        <input type="submit" value="Method1" onclick='this.form.action="@Url.Action("Method1", "Home", null, this.Request.Url.Scheme)"' />
    
        <input type="submit" value="Method2" onclick='this.form.action="@Url.Action("Method2", "Home", null, this.Request.Url.Scheme)"' />
    
    }
