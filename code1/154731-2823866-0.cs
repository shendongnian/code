    public static Image PadImage(Image originalImage)
    {
    	int largestDimension = Math.Max(originalImage.Height, originalImage.Width);
    	Size squareSize = new Size(largestDimension, largestDimension);
    	Bitmap squareImage = new Bitmap(squareSize.Width, squareSize.Height);
    	using (Graphics graphics = Graphics.FromImage(squareImage))
    	{
    		graphics.FillRectangle(Brushes.White, 0, 0, squareSize.Width, squareSize.Height);
    		graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
    		graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
    		graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
    
    		graphics.DrawImage(originalImage, (squareSize.Width / 2) - (originalImage.Width / 2), (squareSize.Height / 2) - (originalImage.Height / 2), originalImage.Width, originalImage.Height);
    	}
    	return squareImage;
    }
