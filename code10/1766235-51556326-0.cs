    public class Details
    {
    	private static readonly Details _instance = new Details();
    
    	static Details() 
    	{
    	}
    	
    	private Details()
    	{
    	}
    
    	public Details Intance
    	{
    		get
    		{
    			return _instance;
    		}
    	}
    	
        public int samplesRead { get; set;}
        public int frequency { get; set;}
    	public List<devices> devices { get; set; }
    }
