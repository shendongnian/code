    public class AChildClass : ABaseClass
    {
    	private readonly Action _doAThing;
    	
    	public AChildClass() { }
    	
    	public AChildClass(Action doAThing)
    	{
    		_doAThing = doAThing;
    	}
    	
    	public override void DoAThing()
    	{
    		if (_doAThing != null)
    		{
    			_doAThing();
    		}
    		
    		print("child override");
    		base.DoAThing();
    	}
    }
