    public class HelperClass<TU>
    {
    	public void RegisterIfObservable<T>(T value) where T: ICollection<TU>
    	{
    		var obs = value as ObservableCollection<T>;
    		if (obs!=null)
    		{
               ...
    		}
    			
    	}
    }
