private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
{
  // do your thing
  ....
  // return results
  e.Results = theResultObject;
}
// now get your results
private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
{
  MyResultObject result = (MyResultObject)e.Result;
  // proces your result...
}
