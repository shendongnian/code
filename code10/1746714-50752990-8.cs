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
            // this is still a reference to action1
    		action += Both;
    		
    		// assignment creates a copy of a delegate
    		actionHandler = action;
    		
            // action is still a reference to action1
            // but actionHandler is a *copy* of action1
    		action += OnlyAction1;
    		actionHandler += OnlyActionHandler;
    		
    		action();
            // Both
            // OnlyAction1
    		
            actionHandler();
            // Both
            // OnlyAction2
    	}
    
    	public static void Both()=> Console.WriteLine("Both");
    	public static void OnlyAction1() => Console.WriteLine("OnlyAction1");
    	public static void OnlyActionHandler() => Console.WriteLine("OnlyActionHandler");
    }
