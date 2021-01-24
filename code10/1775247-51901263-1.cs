    @model Something.Models.MyMainViewModel
    <div>
        <div>
             @Html.Partial("~/Views/MyMain/AddressPartial.cshtml", Model.AddressData)
        </div>
        <div>
             @Html.Partial("~/Views/MyMain/ShoppingCartPartial.cshtml", Model.ShoppingCartData)
        </div>
    </div>
    public class MyMainViewModel : ViewModelBase
    {
    	#region <Constructors>
    
    	public MyMainViewModel(IApplication application) : base(application)
    	{
    		Address = application.Address;
    		ShoppingCart = application.ShoppingCart;
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
    		application.DoAwesomeStuff();
    		
    		var viewModel = new MyMainViewModel(application);
    
            
    		return View("MyView", viewModel);
    	}
    
    	#endregion
    }
