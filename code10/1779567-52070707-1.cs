	public abstract class Shape
	{
		public int X { get; set; }
		public int Y { get; set; }
		public int Width { get; set; }
		public int Height { get; set; }
		public Pen LineColor { get; set; } = Pens.Red;
		public Brush FillColor { get; set; } = null;
		public abstract void Draw(Graphics g);
	}
	
	public class EllipseShape : Shape
	{
		public override void Draw(Graphics g)
		{
			if (FillColor != null)
				g.FillEllipse(FillColor, X, Y, Width, Height);
			g.DrawEllipse(LineColor, X, Y, Width, Height);
		}
	}
	
	public class RectangleShape : Shape
	{
		public override void Draw(Graphics g)
		{
			if (FillColor != null)
				g.FillRectangle(FillColor, X, Y, Width, Height);
			g.DrawRectangle(LineColor, X, Y, Width, Height);
		}
	}
