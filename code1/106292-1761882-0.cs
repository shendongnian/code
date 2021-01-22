        public class baseone
    	{
    		private baseone ()
    		{
    		}
    
    		public baseone ( string huh )
    		{
                    initialise(huh);
    		}
    
    	}
    
    
    	public class niceone : baseone
    	{
    		public niceone ()
    		 : base("info")
    		{
    
    		}
    
    	}
