    public class MyForm : Form
    {
      private BackgroundWorker backgroundWorker = new BackgroundWorker();
      
      public MyForm()
      {
        InitializeComponents();
        backgroundWorker.DoWork += backgroundWorker_DoWork;
        backgroundWorker.RunWorkerCompleted +=
                                    backgroundWorker_RunWorkerCompleted;
        backgroundWorker.RunWorkerAsync();
      }
      
      private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
      {
        e.Result = LookForItWhichMightTakeALongTime();
      }
      
      private void backgroundWorker_RunWorkerCompleted(object sender,
                                                 RunWorkerCompletedEventArgs e)
      {
        found = e.Result as MyClass;
      }
    }
