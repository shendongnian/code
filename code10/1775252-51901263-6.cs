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
    
    	public MyMainViewModel(IApplication application, int id) : base(application)
    	{
    		Address = Application.GetAddress(id); //<-- From the base class
    		ShoppingCart = Application.GetShoppingCart(id); //<-- From the base class
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
        public ActionResult DoSomething(int id)
        {    		
    		var viewModel = new MyMainViewModel(application, id);
    
    		return View("MyView", viewModel);
    	}
    
    	#endregion
    }
    public class ViewModelBase
    {
    	#region <Constructors>
    
    	public ViewModelBase(IApplication application)
    	{
    		Application = (MyApplication)application;
    	}
    
    	#endregion
    
    	#region <Properties>
    
    	protected MyApplication Application { get; set; }
    
    	#endregion
    }
