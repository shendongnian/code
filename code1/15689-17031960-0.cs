    void Main()
    {
    	ClassTest test = new ClassTest();
    	lock(test)
    	{
    		Parallel.Invoke (
    			() => test.DoWorkUsingThisLock(1),
    			() => test.DoWorkUsingThisLock(2)
    		);
    	}
    }
    
    public class ClassTest
    {
    	public void DoWorkUsingThisLock(int i)
    	{
    		Console.WriteLine("Before ClassTest.DoWorkUsingThisLock " + i);
    		lock(this)
    		{
    			Console.WriteLine("ClassTest.DoWorkUsingThisLock " + i);
    			Thread.Sleep(1000);
    		}
    		Console.WriteLine("ClassTest.DoWorkUsingThisLock Done " + i);
    	}
    }
