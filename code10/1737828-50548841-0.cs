    namespace WPFWindow
    {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.Resources.Source = new Uri(@"pack://application:,,,/WPFWindow;component/Themes/Styles.xaml"", UriKind.Absolute);
            InitializeComponent();
        }
    }
