    private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
    {
      // do your thing
      ....
      // return results
      e.Result = theResultObject;
    }
    
    // now get your results
    private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      MyResultObject result = (MyResultObject)e.Result;
      // process your result...
    }
