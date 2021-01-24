    public class UIBindingProperties : BaseViewModel
    {
    	private string name;    
    	public string Name
    	{
    		get => name;
    		set => SetProperty(ref name, value);
    	}
    }
