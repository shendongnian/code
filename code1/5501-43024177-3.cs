    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            this.cbEdge.ItemsSource = new[]
            {
                AppBarDockMode.Left,
                AppBarDockMode.Right,
                AppBarDockMode.Top,
                AppBarDockMode.Bottom
            };
            this.cbMonitor.ItemsSource = MonitorInfo.GetAllMonitors();
        }
        private void btClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void rzThumb_DragCompleted(object sender, DragCompletedEventArgs e)
        {
            this.DockedWidthOrHeight += (int)(e.HorizontalChange / VisualTreeHelper.GetDpi(this).PixelsPerDip);
        }
    }
