    public class BaseViewModel<TModel>
    {
    	public TModel Model
    	{
    		get;
    		private set;
    	}
    	
    	public BaseViewModel(TModel model)
    	{
    		this.Model = model;
    	}
    }
