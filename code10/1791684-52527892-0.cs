    public static class Settings
    {
    	public static bool setting1 { get; set; } = true;
    	public static bool setting2 { get; set; } = false;
    }
    public class mWorker
    {
    	private string wName;
    	private Func<bool> wSetting;
    	
    	public mWorker(string _name, Func<bool> _setting)
    	{
    		wName = _name;
    		wSetting = _setting;
    	}
    	public void doWork()
    	{
    		var onOff = wSetting() ? "ON" : "OFF";
    		Console.WriteLine($"Worker {wName} is turned {onOff}");
    	}
    }
    
    class Program
    {
    	void Main()
    	{
    		// Settings are passed by value when each worker is 
    		// instantiated. I want to pass the constructor   
    		// something that allows each setting to be read 
    		// dynamically whenever it is used. 
    		mWorker worker1 = new mWorker("W1", () => Settings.setting1);
    		mWorker worker2 = new mWorker("W2", () => Settings.setting2);
    
    		Console.WriteLine("\n=====================");
    		worker1.doWork();   // Result: "Worker W1 is turned ON"
    		worker2.doWork();   // Result: "Worker W2 is turned OFF"
    
    		Settings.setting1 = false;
    		Settings.setting2 = true;
    
    		Console.WriteLine("\n=====================");
    		worker1.doWork();   // Result: "Worker W1 is turned OFF"
    		worker2.doWork();   // Result: "Worker W2 is turned ON"
    
    	}
    }
