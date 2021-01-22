        public Form1()
        {
            InitializeComponent();
            backgroundWorker1.WorkerSupportsCancellation = true;
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Process process = new Process();
            process.StartInfo = new ProcessStartInfo("notepad.exe");
            process.Start();
            while (!process.HasExited)
            {
                if (backgroundWorker1.CancellationPending)
                {
                    process.Kill();
                    continue;
                }
                else
                    Thread.Sleep(1000);
            }
        }
        private void Start_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }
        private void Cancel_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }
