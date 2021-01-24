	public static void SaveDrawRectangle(int width, int height, Byte[] matrix, int dpi, List<Point> corners, string path)
	{
		System.Windows.Media.Imaging.WriteableBitmap wbm = new System.Windows.Media.Imaging.WriteableBitmap(width, height, dpi, dpi, System.Windows.Media.PixelFormats.Bgra32, null);
		uint[] pixels = new uint[width * height];
		for (int Y = 0; Y < height; Y++)
		{
			for (int X = 0; X < width; X++)
			{
				byte pixel = matrix[Y * width + X];
				int red = pixel;
				int green = pixel;
				int blue = pixel;
				int alpha = 255;
				if (IsInRectangle(X, Y, corners))
				{
					red = 255;
				}
				pixels[Y * width + X] = (uint)((alpha << 24) + (red << 16) + (green << 8) + blue);
			}
		}
		wbm.WritePixels(new System.Windows.Int32Rect(0, 0, width, height), pixels, width * 4, 0);
		using (FileStream stream5 = new FileStream(path, FileMode.Create))
		{
			PngBitmapEncoder encoder5 = new PngBitmapEncoder();
			encoder5.Frames.Add(BitmapFrame.Create(wbm));
			encoder5.Save(stream5);
		}
	}
	public static bool IsInRectangle(int X, int Y, List<Point> corners)
	{
		Point p1, p2;
		bool inside = false;
		if (corners.Count < 3)
		{
			return inside;
		}
		var oldPoint = new Point(
			corners[corners.Count - 1].X, corners[corners.Count - 1].Y);
		for (int i = 0; i < corners.Count; i++)
		{
			var newPoint = new Point(corners[i].X, corners[i].Y);
			if (newPoint.X > oldPoint.X)
			{
				p1 = oldPoint;
				p2 = newPoint;
			}
			else
			{
				p1 = newPoint;
				p2 = oldPoint;
			}
			if ((newPoint.X < X) == (X <= oldPoint.X)
				&& (Y - (long)p1.Y) * (p2.X - p1.X)
				< (p2.Y - (long)p1.Y) * (X - p1.X))
			{
				inside = !inside;
			}
			oldPoint = newPoint;
		}
		return inside;
	}
