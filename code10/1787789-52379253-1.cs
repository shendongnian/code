    using System;
    
    public class SpaceAge
    {
    	public long seconds;
    	public SpaceAge(long seconds)
    	{
    		this.seconds = seconds; // missing
    		Console.WriteLine("Space Age in Seconds:" + seconds);
    	}
    
    	public double OnEarth()
    	{
    		double result = seconds / 31557600D; // add an 'D'
    		return result;
    	}
    
    	public double OnMercury()
    	{
    		double result = seconds * 0.2408467D; // add an 'D'
    		return result;
    	}
    }
    
    public class Program
    {
    	public static void Main()
    	{
    		Console.WriteLine("**Main Function Executing**");
    		var age = new SpaceAge(10000000000);
    		Console.WriteLine("Earth years:" + age.OnEarth());
    		Console.WriteLine("Mercury years:" + age.OnMercury());
    	}
    }
