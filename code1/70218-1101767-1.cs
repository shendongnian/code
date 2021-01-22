    private void StartQuery(string query)
    {
        BackgroundWorker backgroundWorker1 = new BackgroundWorker();
        backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
        backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
        backgroundWorker1.RunWorkerAsync(query);
    }
    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {   
        e.Result = SQLGet((string)e.Argument);
    }
    private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        queryResult = (string)e.Result;
    }
