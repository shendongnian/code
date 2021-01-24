    using System;
    
    public class Program
    {
    	static Action action1;
    	static Action actionHandler;
    	public static void Main()
    	{
    		WaitForActionProcess(ref action1);
    	}
    
    	public static void WaitForActionProcess(ref Action action)
    	{
    		action += Both;
    		
    		// assignment creates a copy of a delegate
    		actionHandler = action;
    		
    		action += OnlyAction1;
    		actionHandler += OnlyActionHandler;
    		
    		action();
    		actionHandler();
    	}
    
    	public static void Both()=> Console.WriteLine("Both");
    	public static void OnlyAction1() => Console.WriteLine("OnlyAction1");
    	public static void OnlyActionHandler() => Console.WriteLine("OnlyActionHandler");
    }
