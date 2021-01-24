    public class Car
    {
    	public int ID { get; set; }
        public string Brand { get; set; }
    	public string Type { get; set; }
    	public CarDriver CarDriver { get; set; }
    }
    
    public class Driver
    {
    	public Driver()
    	{ }
    	public int ID { get; set; }
    	public string Name { get; set; }
    	public CarDriver CarDriver { get; set; }
    }
    
    public class CarDriver
    {
    	public int CarID { get; set; }
    	public Car Car { get; set; }
    	public int DriverID { get; set; }
    	public virtual Driver Driver { get; set; }
    }
