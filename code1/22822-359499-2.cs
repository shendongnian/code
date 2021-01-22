    public partial class Employees : Page, IEmployeeView
    {
    	private EmployeePresenter _presenter;
    
    	[Dependency]
    	public EmployeePresenter Presenter
    	{
    		set
    		{
    			_presenter = value;
    			_presenter.View = this;
    		}
    	}
    }
