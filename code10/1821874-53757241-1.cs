    public partial class MainWindow : Window
    {
        protected Point SwipeStart;
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Source = new Uri("LeftPage.xaml", UriKind.RelativeOrAbsolute);
        }
        private void Window_MouseDown(object sender, MouseEventArgs e)
        {
            SwipeStart = e.GetPosition(this);
        }
        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var Swipe = e.GetPosition(this);                
                //Swipe Left
                if (SwipeStart != null && Swipe.X > (SwipeStart.X + 200))
                {
                    // OR Use Your Logic to switch between pages.
                    MainFrame.Source = new Uri("LeftPage.xaml", UriKind.RelativeOrAbsolute);
                }
                //Swipe Right
                if (SwipeStart != null && Swipe.X < (SwipeStart.X - 200))
                {
                    // OR Use Your Logic to switch between pages.
                    MainFrame.Source = new Uri("RightPage.xaml", UriKind.RelativeOrAbsolute);
                }
            }
            e.Handled = true;
        }
    }
