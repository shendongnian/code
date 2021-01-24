    public interface ILogger
    {
    	void LogMessage(string message);
    }
    
    public interface IDice
    {
    	int Roll();
    }
    
    public interface IPlayer
    {
    	string Name
    	{
    		get;
    	}
    
    	bool InJail
    	{
    		get;
    		set;
    	}
    
    	int TimeInJail
    	{
    		get;
    		set;
    	}
    }
