	void Main()
	{
		fnPlotter(x1: -1, x2: 1, fn: (double x) => Math.Pow(x, 3));
	}
	
	public static void fnPlotter(double x1=-3, double x2=3, double s=0.05, 
									   double? ymin=null, double? ymax=null, 
									   Func<double, double> fn = null, bool enable3D=true)
	{
		ymin = ymin ?? x1; ymax = ymax ?? x2;
		
		dynamic fArrPair(double p_x1 = -3, double p_x2 = 3, double p_s = 0.01, 
							  Func<double, double> p_fn = null)
		{
			if (p_fn == null) p_fn = ((xf) => { return xf; }); // identity as default
			var xl = new List<double>(); var yl = new List<double>();
			for (var x = p_x1; x <= p_x2; x += p_s)
			{
				double? f = null;
				try { f = p_fn(x); }
				finally
				{
					if (f.HasValue) { xl.Add(x); yl.Add(f.Value); }
				}
			}
			return new { Xs = xl.ToArray(), Ys = yl.ToArray() };
		}
	
		var chrt = new Chart(); var ca = new ChartArea(); chrt.ChartAreas.Add(ca);
		ca.Area3DStyle.Enable3D = enable3D;
		ca.AxisX.Minimum = x1; ca.AxisX.Maximum = x2;	
		ca.AxisY.Minimum = ymin.Value; ca.AxisY.Maximum = ymax.Value;
			
		var sr = new Series(); chrt.Series.Add(sr);
		sr.ChartType = SeriesChartType.Spline; sr.Color = Color.Red;
		sr.MarkerColor = Color.Blue; sr.MarkerStyle = MarkerStyle.Circle;
		sr.MarkerSize = 2;
			
		var bm = new Bitmap(width: chrt.Width, height: chrt.Height);			
		var data = fArrPair(x1, x2, s, fn); sr.Points.DataBindXY(data.Xs, data.Ys);	
		chrt.DrawToBitmap(bm, chrt.Bounds); bm.Dump();
	}
