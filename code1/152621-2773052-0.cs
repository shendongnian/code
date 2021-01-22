    public abstract class Service
    {
    	private readonly int numberOfProducts;
    	private readonly IDictionary<string, int> hours;
    	protected const int SMALL = 2; 
        protected const int MEDIUM = 8;
    	
    	public Service(int numberOfProducts, IDictionary<string, int> hours)
    	{
    		this.numberOfProducts = numberOfProducts;
    		this.hours = hours;
    	}
    	
    	public int GetHours()
    	{
    		if(this.numberOfProducts <= SMALL)
    			return this.CalculateSmallHours(this.hours["small"], this.numberOfProducts);
    		else if(this.numberOfProducts <= MEDIUM)
    			return this.CalculateMediumHours(this.hours["medium"], this.numberOfProducts);
    		else
    			return this.CalculateLargeHours(this.hours["large"], this.numberOfProducts);
    	}
    	
    	protected abstract int CalculateSmallHours(int hours, int numberOfProducts);
    	protected abstract int CalculateMediumHours(int hours, int numberOfProducts);
    	protected abstract int CalculateLargeHours(int hours, int numberOfProducts);
    }
