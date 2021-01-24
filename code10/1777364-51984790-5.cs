    private void buttonWorkerTest_Click(object sender, RoutedEventArgs e)
    {
    	this.progressBarWorkerTest.Value = 0;
    	BackgroundWorker worker = new BackgroundWorker();
    	// Event for the method that will run on the background
    	worker.DoWork += this.Worker_DoWork;
    	// Event that will run after the BackgroundWorker finnish
    	worker.RunWorkerCompleted += this.Worker_RunWorkerCompleted;
    	worker.RunWorkerAsync();
    
    	
    }
    
    private void Worker_DoWork(object sender, DoWorkEventArgs e)
    {
    	for (int i = 1; i <= 100; i++)
    	{
    		Dispatcher.Invoke(new Action(() =>
    		{
    			this.progressBarWorkerTest.Value = i;
    		}));
    		Thread.Sleep(100);
    	}
    }
    
    private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
    	// You can put the code here to open the new form and such
    }
