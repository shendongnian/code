	public interface ICanvasTool
	{
		void Motion(Point newLocation);
		void Tick();
	}
	public abstract class CanvasTool_BaseDraw
	{
		public void Motion(Point newLocation)
		{
			//some implementation
		}
	}
	public class CanvasTool_Spray : CanvasTool_BaseDraw, ICanvasTool
	{
		public void Tick()
		{
			//some implementation
		}
	}
