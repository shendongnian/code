    public partial class MainWindow : Window
    {
        private Thread t1;
    
        public MainWindow()
        {
            InitializeComponent();
        }
    
        private void OnWindowclose(object sender, EventArgs e)
        {
            Environment.Exit(Environment.ExitCode); // Prevent memory leak
            // System.Windows.Application.Current.Shutdown(); // Not sure if needed
        }
    
        private void Start_Click(object sender, RoutedEventArgs e)
        {
            move = true;
            t1 = new System.Threading.Thread(KeepMoving);
            t1.IsBackground = true; // Run in background
            t1.Start();
        }
    
    
        private void KeepMoving()
        {
        // my code
        }
    }
