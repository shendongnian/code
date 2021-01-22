    namespace Phobos.Graphics
    {
    	public class BorderDetector
    	{
    		private Color region1Color = Color.FromArgb(222, 22, 46);
    		private Color region2Color = Color.FromArgb(11, 189, 63);
    		private Color borderColor = Color.FromArgb(11, 189, 63);
    
    		private List<Point> region1Points = new List<Point>();
    		private List<Point> region2Points = new List<Point>();
    		private List<Point> borderPoints = new List<Point>();
    
    		private Bitmap b;
    
    		private const int precision = 10;
    		private const int distanceTreshold = 25;
    
    		public long Miliseconds1 { get; set; }
    		public long Miliseconds2 { get; set; }
    
    		public BorderDetector(Bitmap b)
    		{
    			if (b == null) throw new ArgumentNullException("b");
    
    			this.b = b;
    		}
    
    		private void ScanBitmap()
    		{
    			Color c;
    
    			for (int x = precision; x < this.b.Width; x += BorderDetector.precision)
    			{
    				for (int y = precision; y < this.b.Height; y += BorderDetector.precision)
    				{
    					c = this.b.GetPixel(x, y);
    
    					if (c == region1Color) region1Points.Add(new Point(x, y));
    					else if (c == region2Color) region2Points.Add(new Point(x, y));
    					else if (c == borderColor) borderPoints.Add(new Point(x, y));
    				}
    			}
    		}
    
    		/// <summary>Returns a distance of two points (inaccurate but very fast).</summary>
    		private int GetDistance(Point p1, Point p2)
    		{
    			return Math.Abs(p1.X - p2.X) + Math.Abs(p1.Y - p2.Y);
    		}
    
    		/// <summary>Finds the closests 2 points among the points in the 2 sets.</summary>
    		private int FindClosestPoints(List<Point> r1Points, List<Point> r2Points, out Point foundR1, out Point foundR2)
    		{
    			int minDistance = Int32.MaxValue;
    			int distance = 0;
    
    			foundR1 = Point.Empty;
    			foundR2 = Point.Empty;
    
    			foreach (Point r1 in r1Points)
    				foreach (Point r2 in r2Points)
    				{
    					distance = this.GetDistance(r1, r2);
    
    					if (distance < minDistance)
    					{
    						foundR1 = r1;
    						foundR2 = r2;
    						minDistance = distance;
    					}
    				}
    
    			return minDistance;
    		}
    
    		public bool FindBorder()
    		{
    			Point r1;
    			Point r2;
    
    			Stopwatch watch = new Stopwatch();
    
    			watch.Start();
    			this.ScanBitmap();
    			watch.Stop();
    			this.Miliseconds1 = watch.ElapsedMilliseconds;
    
    			watch.Start();
    			int distance = this.FindClosestPoints(this.region1Points, this.region2Points, out r1, out r2);
    			watch.Stop();
    			this.Miliseconds2 = watch.ElapsedMilliseconds;
    
    			this.b.SetPixel(r1.X, r1.Y, Color.Green);
    			this.b.SetPixel(r2.X, r2.Y, Color.Red);
    
    			return (distance <= BorderDetector.distanceTreshold);
    		}
    	}
    }
