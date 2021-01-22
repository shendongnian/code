	public interface ICar
	{
		public Color Color { get; set; }
		void Drive(int speed);
		void Stop();
	}
	public class Honda : ICar
	{
		#region ICar Members
		public Color Color { get; set; }
		public void Drive(int speed)
		{
			throw new NotImplementedException();
		}
		public void Stop()
		{
			throw new NotImplementedException();
		}
		#endregion
	}
	public class Toyota : ICar
	{
		#region ICar Members
		public Color Color { get; set; }
		public void Drive(int speed)
		{
			throw new NotImplementedException();
		}
		public void Stop()
		{
			throw new NotImplementedException();
		}
		#endregion
	}
