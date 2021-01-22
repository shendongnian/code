    namespace Utility.Extensions
    {
    	public static class Generic
    	{
    		/// <summary>
    		/// Initialize instance.
    		/// </summary>
    		public static T Initialize<T>(this T instance, Action<T> initializer)
    		{
    			initializer(instance);
			    return instance;
    		}
    	}
    }
