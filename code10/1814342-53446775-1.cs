    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void TestMouseDown(object sender, MouseButtonEventArgs e)
        {
            MoveTo(imageTest, 100, 100);
        }
        public static void MoveTo(UIElement target, double newX, double newY)
        {
            //Your code
        }
    }
