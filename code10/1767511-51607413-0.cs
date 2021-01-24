    public partial class MainWindow : Window
    {
        Label label;
        public MainWindow()
        {
            InitializeComponent();
            label = new Label();
            label.Content = "Boop";
            Canvas.SetLeft(label, 100);
            Canvas.SetTop(label, 100);
            canvas.Children.Add(label);
            // Render event - when the controls are at the set location.
            ContentRendered += MainWindow_ContentRendered;
        }
        private void MainWindow_ContentRendered(object sender, EventArgs e)
        {
            PrintLabeLocation();
        }
        // This method allows reuse of code.
        private void PrintLabeLocation()
        {
            Point p = label.TranslatePoint(new Point(0, 0), canvas);
            Console.WriteLine(p);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PrintLabeLocation();
        }
    }
