    private void button1_Click(object sender, EventArgs e)
    {
      label1.Text = "Waiting";
      backgroundWorker1.RunWorkerCompleted += RunWorkerCompleted;
      backgroundWorker1.RunWorkerAsync();
    }
    
    private async void backgroundWorker1_DoWork_1(object sender, System.ComponentModel.DoWorkEventArgs e)
    {
      await Task.Delay(1000);
    }
    
    private async void RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
    {
      label1.Text = "Done";
    }
    	
