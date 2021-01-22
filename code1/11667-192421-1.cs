    public partial class Window1 : Window {
        Class1 c;
        DispatcherTimer t;
        int count = 0;
        public Window1() {
            InitializeComponent();
            t = new DispatcherTimer();
            t.Interval = TimeSpan.FromMilliseconds( 1 );
            t.Tick += new EventHandler( t_Tick );
            t.Start();
        }
        void t_Tick( object sender, EventArgs e ) {
            count++;
            BuildCanvas();
        }
        private static void BuildCanvas() {
            Canvas c = new Canvas();
            Line line = new Line();
            line.X1 = 1;
            line.Y1 = 1;
            line.X2 = 100;
            line.Y2 = 100;
            line.Width = 100;
            c.Children.Add( line );
            c.Measure( new Size( 300, 300 ) );
            c.Arrange( new Rect( 0, 0, 300, 300 ) );
        }
    }
