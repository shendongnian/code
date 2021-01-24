    public class MyCustomTab : TabControl
    {
    	public MyCustomTabPageCollection TabPages { get; set; }
    
    	public MyCustomTab() : base()
    	{
    		base.Width = 200;
    		base.Height = 100;
    		
    	}
    }
