     private readonly BackgroundWorker worker = new BackgroundWorker();
        public MainWindow()
        {
            InitializeComponent();
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
        }
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                Dispatcher.BeginInvoke((Action)(() =>
                {
                    myProgressBar.Value = i;
                }));
                Thread.Sleep(100);
            }
        }
        private void worker_RunWorkerCompleted(object sender,
                                               RunWorkerCompletedEventArgs e)
        {
            myProgressBar.Value = 100;
        }
        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            worker.RunWorkerAsync();
        }
    }
