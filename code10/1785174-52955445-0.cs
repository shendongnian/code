    	/// <summary>
		/// Converts coordinates of a point from the picture box grid into column and row of its image.
		/// </summary>
		/// <param name="pb">The PictureBox.</param>
		/// <param name="ptControl">The point in picture box coordinates (X, Y).</param>
		/// <returns>Point in image coordinates (column, row).</returns>
		private Point ToImageCoordinates(PictureBox pb, Point ptControl)
		{
			if (pb.Image == null)
			{
				return new Point(Int32.MinValue, Int32.MinValue);
			}
			float deltaX	= ptControl.X - rectImage.Left;
			float deltaY	= ptControl.Y - rectImage.Top;
			int column		= (int)(deltaX * (pb.Image.Width / rectImage.Width) + 0.5);
			int row			= (int)(deltaY * (pb.Image.Height / rectImage.Height) + 0.5);
			return new Point(column, row);
		}
		/// <summary>
		/// Converts coordinates of a point from the grid (column, row) into the coordinate system of the picture box.
		/// </summary>
		/// <param name="pb">The PictureBox.</param>
		/// <param name="ptImage">The point in image coordinates (column, row).</param>
		/// <returns>Point in control coordinates (X, Y).</returns>
		private PointF ToControlCoordinates(PictureBox pb, Point ptImage)
		{
			if (pb.Image == null)
			{
				return new Point(Int32.MinValue, Int32.MinValue);
			}
			float deltaX	= ptImage.X * (rectImage.Width / pb.Image.Width);
			float deltaY	= ptImage.Y * (rectImage.Height / pb.Image.Height);
			return new PointF(deltaX + rectImage.Left, deltaY + rectImage.Top);
		}
