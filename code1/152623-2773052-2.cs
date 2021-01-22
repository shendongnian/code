    public class HoursCalculationStrategyCollection
    {
    	private readonly Dictionary<string, int> hours;
    	
    	private readonly Dictionary<string, Func<int, int, int>> strategies;
    	
    	public HoursCalculationStrategyCollection(IDictionary<string, int> hours)
    	{
    		this.hours = hours;
    		this.strategies = new Dictionary<string, Func<int, int, int>();
    	}
    	
    	public void AddCalculationStrategy(string hours, Func<int, int, int> strategy)
    	{
    		this.strategies[hours] = strategy;
    	}
    	
    	public int CalculateHours(int numberOfProducts)
    	{
    		string hoursKey = null;
    		
    		if(numberOfProducts <= SMALL)
    			hoursKey = small;
    		else if(...)
    			...
    		
    		Func<int, int, int> strategy = this.strategies[hoursKey];
    		return strategy(this.hours[hoursKey], numberOfProducts);
    	}
    }
