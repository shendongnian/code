    private void Form1_Load(object sender, EventArgs e)
	{
		BackgroundWorker worker = new BackgroundWorker();
		worker.DoWork += new DoWorkEventHandler(worker_DoWork);
		worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
		worker.RunWorkerAsync();
	}
	void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	{
		// Will cause another exception if an exception didn't occur.
		// We should be checking to see if e.Error is not "null".
		textBox1.Text = "Error? " + e.Error;
	}
	void worker_DoWork(object sender, DoWorkEventArgs e)
	{
		for (int i = 0; i < 10; i++)
		{
			if (i < 5)
			{
				Thread.Sleep(100);
			}
			else
			{
				throw new Exception("BOOM");
			}	
		}
	}
