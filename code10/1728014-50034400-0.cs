    public interface IDevice
    {
    	string GetId();
    }
    
    public class Manager
    {
    
    	public TResult GetDevice<TResult>() 
    		where TResult : IDevice
    	{
    		return (TResult)Device;
    	}
    
    	public IDevice Device
    	{
    		get;
    	}
    }
    
    public interface IBleDevice : IDevice
    {
    	string GetBleId();
    }
