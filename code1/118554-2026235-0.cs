    using System;
    
    public abstract class A
    {
    	protected A()
    	{
    		Console.WriteLine("Constructor A() called");
    	}
     	public void Display()
    	{
    		Console.WriteLine("A.Display() called");
    	}
    }
    
    public class B:A
    {
    	public void UseDisplay()
    	{
    		Display();
    	}
    }
    
    public class Program
    {
    	static void Main()
    	{
    		B b = new B();
    		b.UseDisplay();
    		Console.ReadLine();
    	}
    }
