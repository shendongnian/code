    public partial class MainWindow : Window
    {
        private string perc = ".25";
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            updateStatusDelegate usd = new updateStatusDelegate(
                progressBar.SetValue);
            Dispatcher.Invoke(usd, 
                System.Windows.Threading.DispatcherPriority.Background, 
                new object[] { 
                    System.Windows.Controls.ProgressBar.ValueProperty, 
                    Convert.ToDouble(perc) });
            var dbl = Convert.ToDouble(perc);
            perc = (dbl + .1).ToString();
        }
    }
    public delegate void updateStatusDelegate(DependencyProperty dp, object value);
