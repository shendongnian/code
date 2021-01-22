        public class baseone
    	{
    		private baseone ()
    		{
    		}
    
    		public baseone ( string huh )
    		{
                    initialise(huh);
    		}
    
                protected abstract initialise(string stuff); 
    	}
    
    
    	public class niceone : baseone
    	{
    		public niceone (string param)
    		 : base(param)
    		{
    
    		}
    
                protected override initialise(string stuff)
                {
                   // do stuff..
                }
    	}
