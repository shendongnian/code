    public interface IFormatter<TData, TFormat>
    {
    	TFormat Format(TData data);
    }
    
    public abstract class BaseFormatter<TData> : IFormatter<TData, XElement>
    {
    	// blah blah
    	public XElement Format(TData data)
    	{
    		throw new NotImplementedException();
    	}
    }
