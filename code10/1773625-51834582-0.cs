    public partial class MainWindow : Window
    {
        // FloatingWindow is just a window descendant
        private FloatingWindow floatingWindow;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (floatingWindow == null)
            {
                floatingWindow = new FloatingWindow();
                floatingWindow.Owner = this;
                floatingWindow.Closed += FloatingWindow_Closed;
            }
            floatingWindow.Show();
            floatingWindow.Activate();
        }
        private void FloatingWindow_Closed(object sender, EventArgs e)
        {
            floatingWindow = null;
        }
    }
