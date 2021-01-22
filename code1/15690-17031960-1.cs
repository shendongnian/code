    void Main()
    {
    	//demonstrates why locking on THIS is BADD! (you should never lock on something that is publicly accessible)
    	ClassTest test = new ClassTest();
    	lock(test) //locking on the instance of ClassTest
    	{
    		Console.WriteLine($"CurrentThread {Thread.CurrentThread.ManagedThreadId}");
    		Parallel.Invoke(new Action[]
    		{
    			() => {
    				//this is there to just use up the current main thread. 
    				Console.WriteLine($"CurrentThread {Thread.CurrentThread.ManagedThreadId}");
    				},
    			//none of these will enter the lock section.
    			() => test.DoWorkUsingThisLock(1),//this will dead lock as lock(x) uses Monitor.Enter
    			() => test.DoWorkUsingMonitor(2), //this will not dead lock as it uses Montory.TryEnter
    		});
    	}
    }
    
    public class ClassTest
    {
    	public void DoWorkUsingThisLock(int i)
    	{
    		Console.WriteLine($"Start ClassTest.DoWorkUsingThisLock {i} CurrentThread {Thread.CurrentThread.ManagedThreadId}");
    		lock(this) //this can be bad if someone has locked on this already, as it will cause it to be deadlocked!
    		{
    			Console.WriteLine($"Running: ClassTest.DoWorkUsingThisLock {i} CurrentThread {Thread.CurrentThread.ManagedThreadId}");
    			Thread.Sleep(1000);
    		}
    		Console.WriteLine($"End ClassTest.DoWorkUsingThisLock Done {i}  CurrentThread {Thread.CurrentThread.ManagedThreadId}");
    	}
    
    	public void DoWorkUsingMonitor(int i)
    	{
    		Console.WriteLine($"Start ClassTest.DoWorkUsingMonitor {i} CurrentThread {Thread.CurrentThread.ManagedThreadId}");
    		if (Monitor.TryEnter(this))
    		{
    			Console.WriteLine($"Running: ClassTest.DoWorkUsingMonitor {i} CurrentThread {Thread.CurrentThread.ManagedThreadId}");
    			Thread.Sleep(1000);
    			Monitor.Exit(this);
    		}
    		else
    		{
    			Console.WriteLine($"Skipped lock section!  {i} CurrentThread {Thread.CurrentThread.ManagedThreadId}");
    		}
    
    		Console.WriteLine($"End ClassTest.DoWorkUsingMonitor Done {i} CurrentThread {Thread.CurrentThread.ManagedThreadId}");
    		Console.WriteLine();
    	}
    }
