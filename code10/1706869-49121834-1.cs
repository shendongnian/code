    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            System.Drawing.Image winFormImg = System.Drawing.Image.FromFile("leaves.jpg");
            Image1.Source = ImageUtils.toImageSource(winFormImg, ImageFormat.Jpeg);
        }
    }
