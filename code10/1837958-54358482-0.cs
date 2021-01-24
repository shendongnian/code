	public partial class MainWindow : Window
	{
		private Line CurrentLine;
		public MainWindow()
		{
			InitializeComponent();
		}
		private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
		{			
			var pos = e.GetPosition(theCanvas);
			if (e.ClickCount == 2)
			{
				this.CurrentLine = new Line
				{
					Name = "RangeBearingLine",
					StrokeThickness = 1,
					Stroke = System.Windows.Media.Brushes.Red,
					X1 = pos.X,
					Y1 = pos.Y,
					X2 = pos.X,
					Y2 = pos.Y
				};
				theCanvas.Children.Add(this.CurrentLine);
				e.Handled = true;
			}
			else if ((e.ClickCount == 1) && (this.CurrentLine != null))
			{
				this.CurrentLine.X2 = pos.X;
				this.CurrentLine.Y2 = pos.Y;
				this.CurrentLine = null;
				e.Handled = true;
			}
		}
		private void Canvas_MouseMove(object sender, MouseEventArgs e)
		{
			if (this.CurrentLine == null)
				return;
			var pos = e.GetPosition(theCanvas);
			this.CurrentLine.X2 = pos.X;
			this.CurrentLine.Y2 = pos.Y;
			e.Handled = true;
		}
	}
