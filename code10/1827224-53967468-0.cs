	using System.Drawing;
	using System.Drawing.Imaging;
	namespace yournamespace
	{
		class Program
		{
			private static void Main(string[] args)
			{
				// load an image
				var source = new Bitmap("source.png");
				// create a target image to draw into
				var target = new Bitmap(1000, 1000, PixelFormat.Format32bppRgb);
				// get a context
				using (var graphics = Graphics.FromImage(target))
				{
					// draw an image into it, scaled to a different size
					graphics.DrawImage(source, new Rectangle(250, 250, 500, 500));
					// draw primitives
					using (var pen = new Pen(Brushes.Blue, 10))
						graphics.DrawEllipse(pen, 100, 100, 800, 800);
				}
				// save the target to a file
				target.Save("target.png", ImageFormat.Png);
			}
		}
	}
