    public partial class MainWindow : Window
    {
        private readonly BackgroundWorker worker = new BackgroundWorker();
        AudioLive m_MyLive = new AudioLive();
        Stopwatch stopWatch = new Stopwatch();
        public MainWindow()
        {
            InitializeComponent();
            AddHandler(FrameworkElement.MouseDownEvent, new MouseButtonEventHandler(Button_MouseDown), true);
            AddHandler(FrameworkElement.MouseUpEvent, new MouseButtonEventHandler(Button_MouseUp), true);
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker.WorkerSupportsCancellation = true;
            m_MyLive.Init(this);
        }
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!m_MyLive.IsRecordinginProgress() && !worker.CancellationPending)
            {
                m_MyLive.StartLive();
                stopWatch.Reset();
                stopWatch.Start();
            }
            while (m_MyLive.IsRecordinginProgress() && !worker.CancellationPending)
            {
                
                this.Dispatcher.Invoke(() =>
                {
                    updateLabel(String.Format("{0:0.#}", TimeSpan.FromMilliseconds(stopWatch.ElapsedMilliseconds).TotalSeconds) + " seconds");
                });
            }
        }
        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            m_MyLive.EndLive();
            stopWatch.Stop();
            updateLabel(String.Format("{0:0.#}", TimeSpan.FromMilliseconds(stopWatch.ElapsedMilliseconds).TotalSeconds) + " seconds");
        }
        private void updateLabel(string text)
        {
            RecordBtn.Content = text;
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
