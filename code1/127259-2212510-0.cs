    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(MainWindow_Loaded);
        }
        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var webImage = new BitmapImage(new Uri("http://sstatic.net/so/img/logo.png"));
            var imageControl = new Image();
            imageControl.Source = webImage;
            ContentRoot.Children.Add(imageControl);
        }
    }
