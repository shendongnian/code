     public Form1()
            {
                InitializeComponent();
    
                BackgroundWorker bw = new BackgroundWorker();
                bw.WorkerReportsProgress = true;
                bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
                bw.DoWork += new DoWorkEventHandler(bw_DoWork);
                bw.RunWorkerAsync();
            }
    
            void bw_DoWork(object sender, DoWorkEventArgs e)
            {
                for (int i = 0; i < 10; i++)
                {
                    ((BackgroundWorker)sender).ReportProgress(0, i.ToString());
                }
            }
    
            void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
            {
                listBox1.Items.Add((string)e.UserState);
            }
