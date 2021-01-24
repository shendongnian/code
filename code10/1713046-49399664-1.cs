    [DataContext]
    public abstract class BaseRequest
    {
      [DataMember]
      public virtual List<string> Fields { get; set; }
    }
    
    [DataContext]
    public class RequestWithDefault : BaseRequest
    {
    	private List<string> _fields;
    
    	[DataMember]
    	public override List<string> Fields 
    	{
    		get
    		{
    			if (_fields == null)
    			{
    				_fields = new List<string> { "test" };
    			}
    
    			return _fields;
    		}
    		set
    		{
    			_fields = value;
    		}
      	}
    }
