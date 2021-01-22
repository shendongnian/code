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
    	public abstract string Category { get; }
    	public void DoSomething()
    	{
    		ConsoleWrapper.Write(Category, "Did something");
    	}
    }
    
    public static class ConsoleWrapper
    {
    	public static void Write(string category, string input)
    	{
    		Console.WriteLine("[{0}] {1}", category, input);
    	}
    }
    
    public class WorldListener : Listener
    {
    	public override string Category { get { return "World"; } }
    	public void DoSpecific()
    	{
    		ConsoleWrapper.Write(Category, "I did sth specific!");
    	}
    }
    
    public class MasterListener : Listener
    {
    	public override string Category { get { return "Master"; } }
    	public void DoSpecific()
    	{
    		ConsoleWrapper.Write(Category, "I did sth specific!");
    	}
    }
