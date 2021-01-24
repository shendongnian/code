    class Program
    {
    	static void Main()
    	{
    		Call(new Car());
    
    		Call(new MotorBike());
    	}
    
    	public static void Call(IVehicles vehicle)
    	{
    		Object someIrrelevantObject = vehicle.SomeValue;
    		//here my change begins
    		IPersonalVehicles personalVehicle = (IPersonalVehicles)vehicle;
    		long somePersonalValue = personalVehicle.SomePersonalValue;
    	}
    
    }
    
    public interface IVehicles
    
    {
    	Object SomeValue { get; }
    }
    
    
    public interface IPersonalVehicles
    
    {
    	long SomePersonalValue { get; }
    }
    
    
    public class Car : IVehicles, IPersonalVehicles
    {
    	public long SomePersonalValue => long.MinValue;
    
    	public object SomeValue => "car value";
    }
    
    public class MotorBike : IVehicles, IPersonalVehicles
    {
    	public long SomePersonalValue => long.MaxValue;
    
    	public object SomeValue => "motorbike value";
    }
