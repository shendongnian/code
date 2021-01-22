    public class AppWaitCursor : IDisposable
    {
    	private readonly Control _eventControl;
    
    	public AppWaitCursor(object eventSender = null)
    	{
    		 _eventControl = eventSender as Control;
    		if (_eventControl != null)
    			_eventControl.Enabled = false;
    
    		Application.UseWaitCursor = true;
    		Application.DoEvents();
    	}
    
    	public void Dispose()
    	{
    		if (_eventControl != null)
    			_eventControl.Enabled = true;
    
    		Cursor.Current = Cursors.Default;
    		Application.UseWaitCursor = false;
    	}
    }
