    public class MainPage
    {
    	private UIBindingProperties viewModel = new UIBindingProperties();
    
    	public MainPage()
    	{
    		BindingContext = viewModel;
    	}
    
    	public void SomeMethodInvokedLater()
    	{
    		viewModel.COBRO = "Completely different value than the initial one";
    	}
    }
 
