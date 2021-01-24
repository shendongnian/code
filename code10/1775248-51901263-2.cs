    @model Something.Models.MyMainViewModel
    <div>
        <div>
             @Html.Partial("~/Views/MyMain/AddressPartial.cshtml", Model.Address)
        </div>
        <div>
             @Html.Partial("~/Views/MyMain/ShoppingCartPartial.cshtml", Model.ShoppingCart)
        </div>
    </div>
    public class MyMainViewModel : ViewModelBase
    {
    	#region <Constructors>
    
    	public MyMainViewModel(IApplication application) : base(application)
    	{
    		Address = MyApplication.Address; //<-- From the base class
    		ShoppingCart = MyApplication.ShoppingCart; //<-- From the base class
    	}
    
    	#endregion
    
    	#region <Properties>
    
    	public Address Address { get; set; }
    
    	public ShoppingCart ShoppingCart { get; set; }
    
    	#endregion
    }
    public class MainViewController : BaseController
    {
    	#region <Actions>
        
    	[HttpGet]
        public ActionResult MainView(int documentId)
        {
    		var application = new MyApplication();
    		application.DoAwesomeStuff(); //<--- Your LINQ queries could populate some properties here
    		
    		var viewModel = new MyMainViewModel(application);
    
    		return View("MyView", viewModel);
    	}
    
    	#endregion
    }
