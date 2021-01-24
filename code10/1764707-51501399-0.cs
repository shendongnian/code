        [DllImport("User32.dll")]
        private static extern bool SetCursorPos(int X, int Y);
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var left = Convert.ToInt32(GetActualLeft() + this.ActualWidth / 2);
            var top = Convert.ToInt32(GetActuaTop() + this.ActualHeight / 2);
            SetCursorPos(left, top);
        }
        double GetActualLeft()
        {
            if (this.WindowState == WindowState.Maximized)
            {
                var leftField = typeof(Window).GetField("_actualLeft", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                return (double)leftField.GetValue(this);
            }
            else
                return this.Left;
        }
        double GetActuaTop()
        {
            if (this.WindowState == WindowState.Maximized)
            {
                var topField = typeof(Window).GetField("_actualTop", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                return (double)topField.GetValue(this);
            }
            else
                return this.Top;
        }
