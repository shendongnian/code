        void worker_Start()
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork +=
                new DoWorkEventHandler(worker_DoWork);
            worker.RunWorkerCompleted +=
                new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            worker.RunWorkerAsync("MyArg");
        }
        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
             e.Result = new Formular();
        }
        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Controls.Add((Control)e.Result);
        }
