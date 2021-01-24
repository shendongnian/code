    public class ConsoleLogger : ILogger
    {
    	public void LogMessage(string message)
    	{
    		Console.WriteLine(message);
    	}
    }
    
    public class Dice : IDice
    {
    	private readonly Random random = new Random();
    	public int Roll()
    	{
    		return this.random.Next(1, 6);
    	}
    }
