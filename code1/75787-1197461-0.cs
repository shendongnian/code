    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        BackgroundWorker worker = sender as BackGroundWorker;
        while(!e.CancellationPending)
        {
            ResultObject ro = new ResultObject();  // your own type here, obviously
            //Process and store some data in ro;
            worker.ReportProgress(0, ro);
            //Do not modify ro after reporting progress to avoid threading issues
        }
    }
