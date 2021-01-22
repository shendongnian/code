    void Main()
    {
    	var wl = new WorldListener();
    	wl.DoSomething();
    	wl.DoSpecific();
    	var ml = new MasterListener();
    	ml.DoSomething();
    	ml.DoSpecific();
    }
    
    public abstract class Listener
    {
    	public void DoSomething()
    	{
    		if (this is WorldListener)
    			ConsoleWrapper.WorldWrite("Did something");
    		if (this is MasterListener)
    			ConsoleWrapper.MasterWrite("Did something");
    	}
    }
    
    public static class ConsoleWrapper
    {
    	public static void WorldWrite(string input)
    	{
    		Console.WriteLine("[World] {0}", input);
    	}
    	
    	public static void MasterWrite(string input)
    	{
    		Console.WriteLine("[Master] {0}", input);
    	}
    }
    
    public class WorldListener : Listener
    {
    	public void DoSpecific()
    	{
    		ConsoleWrapper.WorldWrite("I did sth specific!");
    	}
    }
    
    public class MasterListener : Listener
    {
    	public void DoSpecific()
    	{
    		ConsoleWrapper.MasterWrite("I did sth specific!");
    	}
    }
