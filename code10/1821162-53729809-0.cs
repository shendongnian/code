    public partial class MainWindow : Window
    {
        private readonly BackgroundWorker worker = new BackgroundWorker();
        int progress = 0;
        public MainWindow()
        {
            InitializeComponent();
            AddHandler(FrameworkElement.MouseDownEvent, new MouseButtonEventHandler(Button_MouseDown), true);
            AddHandler(FrameworkElement.MouseUpEvent, new MouseButtonEventHandler(Button_MouseUp), true);
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker.WorkerSupportsCancellation = true;
        }
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!worker.CancellationPending)
            {
                progress++;
            }
        }
        private void worker_RunWorkerCompleted(object sender,
                                               RunWorkerCompletedEventArgs e)
        {
            //update ui once worker complete his work
            var final = progress;
        }
        private void Button_MouseDown(object sender, MouseButtonEventArgs e)
        {
            worker.RunWorkerAsync();
        }
        private void Button_MouseUp(object sender, MouseButtonEventArgs e)
        {
            worker.CancelAsync();
        }
    }
