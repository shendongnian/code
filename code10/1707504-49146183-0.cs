    public interface IMessageBox
    {
	    MessageBoxResult Show(string msg);
    }
    public class SomeClass
    {
    	private readonly IMessageBox _messageBox;
    
    	public SomeClass(IMessageBox messageBox)
    	{
    		_messageBox = messageBox;
    	}
    
    	public bool SomeFunction()
    	{
    		MessageBoxResult mResult = _messageBox.Show("Displaying message");
    		bool result;
    		if(mResult == MessageBoxResult.OK)
    		{
    		    result = AnyFunction();
    		}
    		return result;
    	}
    }
    
