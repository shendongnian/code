    public class ClonedObject
    {
    	public event EventHandler OnIdChanged;
    	public event EventHandler OnNameChanged;
    
    	public void ClearEvents()
    	{
    		OnIdChanged = null;
    		OnNameChanged = null;
    	}
    }
