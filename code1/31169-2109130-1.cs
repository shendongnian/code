    namespace Server
    {
    	public class CountingService : MarshalByRefObject, ICountingService
    	{
    		private static int _value = 0;
    
    		public CountingService(int startValue)
    		{
    			_value = startValue;
    		}
    
    		public int Increment()
    		{ // not threadsafe!
    			_value++;
    			return _value;
    		}
    	}
    }
