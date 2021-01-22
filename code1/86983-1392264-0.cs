     public interface IPointy
	{
		void Draw();
	}
	public class PointyImplementer : IPointy
	{
		#region IPointy Members
		void IPointy.Draw()
		{
			Console.WriteLine("You have drawn");
		}
		#endregion
	}
	class Program
	{
		static void Main(string[] args)
		{
			IPointy pi = new PointyImplementer();
			pi.Draw();
			Console.Read();
		}
	}
