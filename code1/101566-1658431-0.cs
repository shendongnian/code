    BackgroundWorker bw = new BackgroundWorker();
    bw.DoWork += new DoWorkEventHandler(bw_DoWork);
    bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler
                                       (bw_RunWorkerCompleted);
    ....
    private void button1_Click(object sender, EventArgs e)
    {
        bw.RunWorkerAsync(filename);
    }
    
    static void bw_DoWork(object sender, DoWorkEventArgs e)
    {
        BackgroundWorker worker = (BackgroundWorker)sender;
        string filename = (string)e.Argument;
        e.Result = DoConversion(filename);
    }
    
    static void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        label.Text = "Done: " + e.Result.ToString();
        DoSomethingWhenConversionComplete();
    }
