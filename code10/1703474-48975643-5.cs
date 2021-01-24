    public abstract class Vehicle
    {
    	public abstract void PrintRouteStatus();
    }
    
    public class MotorwayInfo
    {
    }
    
    public class CycleInfo
    {
    }
    
    public class Car : Vehicle
    {
        // probably pass this in via a constructor.
    	public MotorwayInfo _motorwayInfo = new MotorwayInfo();
    	public override void PrintRouteStatus()
    	{
    		Console.WriteLine(_motorwayInfo);
    	}
    }
    
    public class Bike : Vehicle
    {
        // probably pass this in via a constructor.
    	public CycleInfo _cycleInfo = new CycleInfo();
    	public override void PrintRouteStatus()
    	{
    		Console.WriteLine(_cycleInfo);
    	}
    }
