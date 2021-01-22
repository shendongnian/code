	static class GraphicsExtension
	{
		private static GraphicsPath GenerateRoundedRectangle(
			this Graphics graphics,
			RectangleF rectangle,
			float radius)
		{
			float diameter;
			GraphicsPath path = new GraphicsPath();
			if (radius <= 0.0F)
			{
				path.AddRectangle(rectangle);
				path.CloseFigure();
				return path;
			}
			else
			{
				if (radius >= (Math.Min(rectangle.Width, rectangle.Height)) / 2.0)
					return graphics.GenerateCapsule(rectangle);
				diameter = radius * 2.0F;
				SizeF sizeF = new SizeF(diameter, diameter);
				RectangleF arc = new RectangleF(rectangle.Location, sizeF);
				path.AddArc(arc, 180, 90);
				arc.X = rectangle.Right - diameter;
				path.AddArc(arc, 270, 90);
				arc.Y = rectangle.Bottom - diameter;
				path.AddArc(arc, 0, 90);
				arc.X = rectangle.Left;
				path.AddArc(arc, 90, 90);
				path.CloseFigure();
			}
			return path;
		}
		/// <summary>
		/// Draws a rounded rectangle specified by a pair of coordinates, a width, a height and the radius
		/// for the arcs that make the rounded edges.
		/// </summary>
		/// <param name="brush">System.Drawing.Pen that determines the color, width and style of the rectangle.</param>
		/// <param name="x">The x-coordinate of the upper-left corner of the rectangle to draw.</param>
		/// <param name="y">The y-coordinate of the upper-left corner of the rectangle to draw.</param>
		/// <param name="width">Width of the rectangle to draw.</param>
		/// <param name="height">Height of the rectangle to draw.</param>
		/// <param name="radius">The radius of the arc used for the rounded edges.</param>
		public static void DrawRoundedRectangle(
			this Graphics graphics,
			Pen pen,
			float x,
			float y,
			float width,
			float height,
			float radius)
		{
			RectangleF rectangle = new RectangleF(x, y, width, height);
			GraphicsPath path = graphics.GenerateRoundedRectangle(rectangle, radius);
			SmoothingMode old = graphics.SmoothingMode;
			graphics.SmoothingMode = SmoothingMode.AntiAlias;
			graphics.DrawPath(pen, path);
			graphics.SmoothingMode = old;
		}
		/// <summary>
		/// Draws a rounded rectangle specified by a pair of coordinates, a width, a height and the radius
		/// for the arcs that make the rounded edges.
		/// </summary>
		/// <param name="brush">System.Drawing.Pen that determines the color, width and style of the rectangle.</param>
		/// <param name="x">The x-coordinate of the upper-left corner of the rectangle to draw.</param>
		/// <param name="y">The y-coordinate of the upper-left corner of the rectangle to draw.</param>
		/// <param name="width">Width of the rectangle to draw.</param>
		/// <param name="height">Height of the rectangle to draw.</param>
		/// <param name="radius">The radius of the arc used for the rounded edges.</param>
		public static void DrawRoundedRectangle(
			this Graphics graphics,
			Pen pen,
			int x,
			int y,
			int width,
			int height,
			int radius)
		{
			graphics.DrawRoundedRectangle(
				pen,
				Convert.ToSingle(x),
				Convert.ToSingle(y),
				Convert.ToSingle(width),
				Convert.ToSingle(height),
				Convert.ToSingle(radius));
		}
    }
