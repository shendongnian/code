    private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)// progress change
    {
       progressBar1.Value = e.ProgressPercentage;
       string line = (string) e.State;
       Mylist.Add(line);  // ok, this runs on the main thread
    }
