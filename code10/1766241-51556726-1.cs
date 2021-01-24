    public static class Details{
        public static int samplesRead { get; set;} 
    	public static int frequency { get; set; }
    	public static List<devices> devices { get; set; } 
    	
    	public static DetailsSnapshot MakeSnapShot()
    	{
    		return new DetailsSnapshot
    		{
    			samplesRead = samplesRead,
    			frequency = frequency,
    			devices = devices
    		}
    	}
    }
