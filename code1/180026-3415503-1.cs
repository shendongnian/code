	public interface ICar
	{
		void Drive();
	}
	public class Car : ICar
	{
		public void Drive()
		{
			Console.WriteLine("vroom");
		}
	}
	public class BuckleUp : ICar
	{
		ICar car;
		public BuckleUp(ICar car) { this.car = car; }
		public void Drive()
		{
			Console.WriteLine("click!");
			car.Drive();
		}
	}
	public class CheckMirrors : ICar
	{
		ICar car;
		public CheckMirrors(ICar car) { this.car = car; }
		public void Drive()
		{
			Console.WriteLine("mirrors adjusted");
			car.Drive();
		}
	}
