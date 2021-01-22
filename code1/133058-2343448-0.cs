            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.RunWorkerAsync();
        }
        static Timer _t;
        static void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            _t = new Timer();
            _t.Start();
        }
