    private BackgroundWorker bw;
    
    private void foobar() {
      bw = new BackgroundWorker(); // should be called once, in ctor
      bw.DoWork += new DoWorkEventHandler(bw_DoWork);
      bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_Completed);
    
      int i = 0;
      bw.RunWorkerAsync(i);
    }
    
    private void bw_DoWork(object sender, DoWorkEventArgs e) {
      int i = (int)e.Argument;
      i++;
      e.Result = i;
    }
    
    private void bw_Completed(object sender, RunWorkerCompletedEventArgs e) {
      if (e.Error != null) {
        MessageBox.Show(e.Error.Message);
      } else {
        int i = (int)e.Result;
        MessageBox.Show(i.ToString());
      }
    }
