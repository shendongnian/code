    public class A
    {
    	public void print(int x, int y)
    	{
    		Console.WriteLine("Parent Method");
    	}
    }
    
    public class B : A
    {
    	public void child()
    	{
    		Console.WriteLine("Child Method");
    	}
    
    	public void print(float x, float y)
    	{
    		Console.WriteLine("Overload child method");
    	}
    }
                           
