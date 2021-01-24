    public class MainWindow :...
    {
        Progress<string> _progress;
        public MainWindow()
        {
            InitializeComponent();
            _progress=new Progress<string>(OnProgress);
        }
        private void OnProgress(string message)
        {
            txtError.Text = message; 
        }
        public void MethodThatStartsMonitoring()
        {
            //This could be passed in a constructor too.
            myMonitor.StartMonitoring(_progress);
        }
    }
