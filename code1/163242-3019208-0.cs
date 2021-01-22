    private void bgWorker_ReportProgress(object sender, ProgressChangedEventArgs e)
    {
      //System.Windows.Threading.Dispatcher disp = button1.Dispatcher;
      //disp.BeginInvoke(myProgressReporter,e.ProgressPercentage);
      progressBar1.Value = progressPercentage; // safe because we're on the main Thread here
    }
