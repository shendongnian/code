    public sealed class SessionKey
    {
    	private _value;	
    	private SessionKey( string value )
    	{
    		_value = value;
    	}
    
    	public string Value { get return _value; }
    
    	public static readonly SessionKey Value1 = new SessionKey( "Value1" );
    	public static readonly SessionKey Value2 = new SessionKey( "Value2" );
    }
    
    public class Something
    {
        /* stuff */
    	public void Foo( SessionKey sessionKey )
    	{
    		switch( sessionKey.Value )
    		{
    			case SessionKey.Value1.Value:
    				DoBaz();
    				break;
    			case SessionKey.Value2.Value:
    				DoBop();
    				break;
    			default:
    				DoBar();
    		}
    	}	
        
        /* other stuff */
    }
