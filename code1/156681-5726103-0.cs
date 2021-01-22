    public class MyControl : Control
    {
    	private Canvas myCanvas;
    
    	public override void OnApplyTemplate()
    	{
    		Canvas theCanvas = Template.FindName("syringeCanvas", this) as Canvas;
    		
    		if(theCanvas != null)
    		{
    			//<-- Save a reference to the canvas
    			myCanvas = theCanvas;
    			
    			//<-- Do some stuff.
    		}
    	}
    }
