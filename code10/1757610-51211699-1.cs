    public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                DispatcherTimer dt = new System.Windows.Threading.DispatcherTimer();
                dt.Tick += new EventHandler(timer_tick);
                dt.Tick += new EventHandler(move_mouse);
                dt.Interval = new TimeSpan(0, 0, 0, 0, 10000);
                dt.Start();
            }
    
            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool GetCursorPos(out POINT pPoint);
    
            [DllImport("user32.dll")]
            public static extern bool SetCursorPos(int new_x, int new_y);
            
            private void timer_tick(object sender, EventArgs e)
            {
                POINT pnt;
                GetCursorPos(out pnt);
                tbMouse_X.Text = (pnt.X).ToString();
                tbMouse_Y.Text = (pnt.Y).ToString();
            }
    
            public void move_mouse(object sender, EventArgs e)
            {
                Random rnd = new Random();
                int A = rnd.Next(0, 1000);
                int B = rnd.Next(0, 1000);
                
                SetCursorPos(A, B);
                
                tbMouse_A.Text = A.ToString();
                tbMouse_B.Text = B.ToString();           
            }
    
            public struct POINT
            {
                public int X;
                public int Y;
    
                public POINT(int x, int y)
                {
                    this.X = x;
                    this.Y = y;
                }
            }
        }
