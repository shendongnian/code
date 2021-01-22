        public static class NullableInt32Extensions
    	{
    		public static Boolean IsSet(this Nullable<Int32> value)
    		{
    			return value.HasValue;
    		}		
    	}
