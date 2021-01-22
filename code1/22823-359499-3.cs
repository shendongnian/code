    public class EmployeePresenter : Presenter<IEmployeeView>
    {
    	private readonly IEmployeeController _controller;
    
    	[InjectionConstructor]
    	}
    	public EmployeePresenter(IEmployeeController controller)
    	{
    		_controller = controller;
    }
