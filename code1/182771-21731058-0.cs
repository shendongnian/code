        public Form1()
        {
            InitializeComponent();
            
            BackgroundWorker bw = new BackgroundWorker();
            bw.WorkerSupportsCancellation = true;
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.RunWorkerAsync();  // start up your spashscreen thread
            startMainForm();      // do all your time consuming stuff here  
            bw.CancelAsync();     // close your splashscreen threas  
        }
        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            SplashScreen ss = new SplashScreen();
            ss.Show();
            
            while (!worker.CancellationPending) //just hangout and wait
            {
                Thread.Sleep(1000);
            }
            if (worker.CancellationPending)
            {
                ss.Close();
                e.Cancel = true;
            }
        }
