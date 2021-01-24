    public abstract class MyBaseControl : ContentControl
    {
    	public MyBaseControl()
    	{
    		(App.Current as MyApp).TimeToCleanUp += CleanItUp;
    	}
    		
    	public virtual void CleanItUp()
    	{
    		(App.Current as MyApp).TimeToCleanUp -= CleanItUp;
    		//do stuff;
    	}
    }
