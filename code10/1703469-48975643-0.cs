	public static void Main()
	{
		var foo = new Car();
		var bar = new Bike();
		
		bar.PrintRouteStatus();
		foo.PrintRouteStatus();
	}
	public abstract class Vehicle
	{
		public abstract void PrintRouteStatus();
	}
	public class MotorwayInfo { }
	public class CycleInfo { }
	public class Car : Vehicle
	{
		public MotorwayInfo _motorwayInfo = new MotorwayInfo();
		public override void PrintRouteStatus()
		{
			Console.WriteLine(_motorwayInfo);
		}
	}
	public class Bike : Vehicle
	{
		public CycleInfo _cycleInfo = new CycleInfo();
		public override void PrintRouteStatus()
		{
			Console.WriteLine(_cycleInfo);
		}
	}
