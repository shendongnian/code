    public class ViewModel : BindableBase
    {
    	public DelegateCommand<string> ProcessAmount { get; set; }
    
    	public ViewModel()
    	{
    		ProcessAmount = new DelegateCommand<string>(HandleProcessAmount, CanProcessAmount);
    	}
    
    	private bool CanProcessAmount(string amountStr)
    	{
    		try
    		{
    			return Convert.ToDecimal(amountStr) != 0;
    		}
    		catch (Exception)
    		{
    			return false;
    		}
    	}
    
    	private void HandleProcessAmount(string amount)
    	{
    		// do something with the amount
    	}
    }
