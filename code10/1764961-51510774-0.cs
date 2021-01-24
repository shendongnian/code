    using System;
    using System.Collections.Generic;
    public class Car
    {
    	public void Start()
    	{
    		Console.WriteLine("Start Car");
    	}
    	public void Accelerate()
    	{
    		Console.WriteLine("Accelerate Car");
    	}
    }
    public class Bike
    {
    	public void Start()
    	{
    		Console.WriteLine("Start Bike");
    	}
    	public void Accelerate()
    	{
    		Console.WriteLine("Accelerate Bike");
    	}
    }
    interface IDriveable
    {
    	void Start();	
    	void Accelerate();		
    }
    class CarChild : Car, IDriveable
    {
    	//To hide the parent's function we use 'new'. We can call parent's functio by base.
    	public new void Accelerate()
    	{
    		base.Accelerate();
    		Console.WriteLine("Accelerate CarChild");
    	}
    }
    class BikeChild: Bike, IDriveable
    {
    	
    }
    					
    public class Program
    {
    	public static void Main()
    	{
    		List<IDriveable> devices = new List<IDriveable>();
    		devices.Add(new CarChild());
    		devices.Add(new BikeChild());
    		SkimAll(devices);
    	}
    	private static void SkimAll(List<IDriveable> devices)
    	{
    		foreach(var device in devices)
    		{
    			device.Start();
    			device.Accelerate();
    		}
    	}
    }
