    public partial class Window_SelectConnection : Window
    {
        public Window_SelectConnection()
        {
            InitializeComponent();
            Loaded += OnLoaded;
        }
        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            SizeToContent = SizeToContent.WidthAndHeight;
            Loaded -= OnLoaded;
        }
    }
