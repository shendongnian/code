	public partial class MainWindow : Window
	{
		public List<object> ChartElements { get; } = new List<object>
		{
			new Waypoint{X=100, Y=100 },
			new Waypoint{X=500, Y=300 },
			new Waypoint{X=300, Y=500 },
			new Waypoint{X=800, Y=700 },
			new NavigationLine{X1=100, Y1=100, X2=500, Y2=300},
			new NavigationLine{X1=500, Y1=300, X2=300, Y2=500},
			new NavigationLine{X1=300, Y1=500, X2=800, Y2=700}
		};
		public MainWindow()
		{
			InitializeComponent();
			this.DataContext = this;
		}
	}
	public class Waypoint
	{
		public int Layer { get; } = 1; // waypoint circles should always appear on top
		public double X { get; set; }
		public double Y { get; set; }
	}
	public class NavigationLine
	{
		public int Layer { get; } = 0;
		public double X1 { get; set; }
		public double Y1 { get; set; }
		public double X2 { get; set; }
		public double Y2 { get; set; }
		public double X => this.X1;
		public double Y => this.Y1;
		public double Width => this.X2 - this.X1;
		public double Height => this.Y2 - this.Y1;
	}
