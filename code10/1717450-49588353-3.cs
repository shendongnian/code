    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
            Canvas canvas = new Canvas();
            Rectangle rect = new Rectangle { Width = 20, Height = 20, Fill = Brushes.Blue };
            Canvas.SetLeft(rect, 50);
            Canvas.SetTop(rect, 50);
            canvas.Children.Add(rect );
            this.Content = canvas;
            canvas.AddHandler(FrameworkElement.MouseLeftButtonDownEvent, new RoutedEventHandler(Canvas_MouseDown));
        }
        private void Canvas_MouseDown(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You clicked me");
        }
    }
