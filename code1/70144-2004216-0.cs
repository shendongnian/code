    public class DataObjectJavaScriptConverter : JavaScriptConverter
    {
    	private static readonly Type[] _supportedTypes = new[]
    	{
    		typeof( DataObject )
    	};
    
    	public override IEnumerable<Type> SupportedTypes 
        { 
            get { return _supportedTypes; } 
        }
    
    	public override object Deserialize( IDictionary<string, object> dictionary, 
                                            Type type, 
                                            JavaScriptSerializer serializer )
    	{
    		if( type == typeof( DataObject ) )
    		{
    			var obj = new DataObject();
    			if( dictionary.ContainsKey( "user_id" ) )
    				obj.UserId = serializer.ConvertToType<int>( 
                                               dictionary["user_id"] );
    			if( dictionary.ContainsKey( "detail_level" ) )
    				obj.DetailLevel = serializer.ConvertToType<DetailLevel>(
                                               dictionary["detail_level"] );
    			
    			return obj;
    		}
    
    		return null;
    	}
    
    	public override IDictionary<string, object> Serialize( 
                object obj, 
                JavaScriptSerializer serializer )
    	{
    		var dataObj = obj as DataObject;
    		if( dataObj != null )
    		{
    			return new Dictionary<string,object>
    			{
    				{"user_id", dataObj.UserId },
    				{"detail_level", dataObj.DetailLevel }
    			}
    		}
    		return new Dictionary<string, object>();
    	}
    }
