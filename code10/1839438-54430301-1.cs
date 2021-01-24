    void FloodFill2(Bitmap bmp, Point pt, Color target, Color replacementColor)
    {
		Stack<(Point point, Color target)> pixels = new Stack<(Point, Color)>();
		pixels.Push((pt, target));
        while (pixels.Count > 0)
    	{
    		var curr = pixels.Pop();
    		var a = curr.point;
    		Color targetColor = curr.target;
    
    		if (a.X < bmp.Width && a.X > 0 &&
    				a.Y < bmp.Height && a.Y > 0)//make sure we stay within bounds
    		{
    			var tolerance = 10;
    			var green = Math.Abs(targetColor.G - bmp.GetPixel(a.X, a.Y).G) < tolerance;
    			var red = Math.Abs(targetColor.R - bmp.GetPixel(a.X, a.Y).R) < tolerance;
    			var blue = Math.Abs(targetColor.B - bmp.GetPixel(a.X, a.Y).B) < tolerance;
    
    			if (red == true && blue == true && green == true)
    			{
    				var old = bmp.GetPixel(a.X, a.Y);
    				bmp.SetPixel(a.X, a.Y, replacementColor);
    				pixels.Push((new Point(a.X - 1, a.Y), old));
    				pixels.Push((new Point(a.X + 1, a.Y), old));
    				pixels.Push((new Point(a.X, a.Y - 1), old));
    				pixels.Push((new Point(a.X, a.Y + 1), old));
    			}
    		}
    	}
    	//refresh our main picture box
        pictureBox1.Image = bmp;
        pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        return;
    }
