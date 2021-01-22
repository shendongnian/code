    namespace System
    {
    	public static class Exceptions
    	{
    		/// <summary>
    		/// Checks for null.
    		/// </summary>
    		/// <param name="thing">The thing.</param>
    		/// <param name="message">The message.</param>
    		public static T CheckForNull<T>( this T thing, string message )
    		{
    			if ( thing == null ) throw new NullReferenceException(message);
    			return thing;
    		}
    
    		/// <summary>
    		/// Checks for null.
    		/// </summary>
    		/// <param name="thing">The thing.</param>
    		public static T CheckForNull<T>( this T thing )
    		{
    			if ( thing == null ) throw new NullReferenceException();
    			return thing;
    		}
    	}
    }
