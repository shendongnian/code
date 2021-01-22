    class Form1 : Form
    {
        private BackgroundWorker Worker { get; set; }
        public Form1()
        {
            Worker = new BackgroundWorker();
            Worker.WorkerSupportsCancellation = true;
            Worker.DoWork += OnWorkerDoWork;
            Worker.RunWorkerCompleted += OnWorkerRunWorkerCompleted;
            // at some point start the worker.
            Worker.RunWorkerAsync();
        }
        void OnWorkerDoWork(object sender, RunWorkerCompletedEventArgs e)
        {
            foreach(var data in someData)
            {
                // if cancelled
                if (e.Cancelled)
                    return;
                AddDataToColumn(someData.Var1, someData, Var2, someData.Var3);
            }
        }
        void OnWorkerRunWorkerCompleted(object sender, DoWorkEventArgs e)
        {
        }
        private delegate void AddDataToColumnDelegate(string var1, string var2, string var3);
        private void AddDataToColumn(string var1, string var2, string var3)
        {
            // check if cross-thread operation
            if (InvokeRequired)
            {
                Invoke(new AddDataToColumnDelegate(AddDataToColumn), var1, var2, var3);
                return;
            }
            // Add data to column
            dataGridView1.Rows.Add(var1, var2, var3);
        }
    }
