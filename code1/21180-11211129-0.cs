    namespace System
    {
    	public static class TypeExtensions
    	{
    		public static object Default(this Type type)
    		{
    			object output = null;
    
    			if (type.IsValueType)
    			{
    				output = Activator.CreateInstance(type);
    			}
    
    			return output;
    		}
    	}
    }
