    private void button1_Click(object sender, EventArgs e) {
      backgroundWorker1.RunWorkerAsync();
      // Do something while the BGW runs
      //...
      System.Threading.Thread.Sleep(500);
      // Wait for the result to be available
      while (backgroundWorker1.IsBusy)
        System.Threading.Thread.Sleep(10);
    }
    
    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e) {
      // Do some work
      //...
      System.Threading.Thread.Sleep(1000);  // Pretend to do some work
      e.Result = 42;
    }
    
    private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
      // Store the result...
    }
