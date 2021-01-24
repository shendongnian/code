	public class FastChart : FrameworkElement
	{
		private Pen ChartPen;
		private const int MaxSampleVal = 1000;
		private const int NumSamples = 10000;
		private int[] Samples = new int[NumSamples];
		public FastChart()
		{
			this.ChartPen = new Pen(Brushes.Blue, 1);
			if (this.ChartPen.CanFreeze)
				this.ChartPen.Freeze();
			ClipToBounds = true;
			this.SnapsToDevicePixels = true;
			CompositionTarget.Rendering += CompositionTarget_Rendering;
			var rng = new Random();
			for (int i = 0; i < NumSamples; i++)
				this.Samples[i] = MaxSampleVal / 2;
		}
		private void CompositionTarget_Rendering(object sender, EventArgs e)
		{
			// update all samples
			var rng = new Random();
			for (int i = 0; i < NumSamples; i++)
				this.Samples[i] = Math.Max(0, Math.Min(MaxSampleVal, this.Samples[i] + rng.Next(11) - 5));
			// force an update
			InvalidateVisual();
		}
		protected override void OnRender(DrawingContext drawingContext)
		{
			// hacky clip to parent scroller
			var minx = 0;
			var maxx = NumSamples;
			var scroller = this.Parent as ScrollViewer;
			if (scroller != null)
			{
				minx = Math.Min((int)scroller.HorizontalOffset, NumSamples - 1);
				maxx = Math.Min(NumSamples, minx + (int)scroller.ViewportWidth);
			}
			for (int x = minx; x < maxx; x++)
				drawingContext.DrawLine(this.ChartPen, new Point(0.5 + x, 1000), new Point(0.5 + x, 1000 - this.Samples[x]));
		}
	}
