    public static class Details
    {
        public static int samplesRead { get; set;} = 100;
    	public static int frequency { get; set; } = 2700;
    	public static List<device> devices { get; set; } = new List<device>() 
    	{ 
    		new device { Name = "sensor1" }, 
    		new device { Name = "sensor 2" } 
    	};
    }
    public class device 
    {
    	public string Name { get; set; }
    }
