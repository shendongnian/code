    public static class GenericJsonSerializer
    {
    	public static T Deserialize<T>(Stream steam) where T :  IDeserializable<T>, new()
    	{
    		using (var reader = ...)
    		{
    			var result = new T();
    			result.FromJson(reader);
    			
    			return result;
    		}
    	}
    }
