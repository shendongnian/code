    public class Car
    {
    	public string Brand;
    	public DateTime Date;
    	public double Amount;
    	public BusinessType BusinessType;
    }
    
    public enum BusinessType
    {
    	Bought = -1,
    	Sold = 1
    }
