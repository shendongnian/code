    private void buttonWorkerTest_Click(object sender, RoutedEventArgs e)
    {
    	this.progressBarWorkerTest.Value = 0;
    	BackgroundWorker worker = new BackgroundWorker();
    	worker.DoWork += this.Worker_DoWork;
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
