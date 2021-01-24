    void bgWorker_DoWork(object sender, DoWorkEventArgs e)
    {
        while (!bgw.CancellationPending)
        {
            System.Threading.Thread.Sleep(new TimeSpan(0, 0, 30));
            var status = ResultOfPing(e.Argument as Uri);
            bgw.ReportProgress(0, status);
        }
        e.Cancel = true;
    }
