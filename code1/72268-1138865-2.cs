    class DoSomething
    {
	string result;
		public void RunAsync()
		{
			var t = new BackgroundWorker();
			t.DoWork += (sender, e) =>
			{
				result = string.Empty; // your code goes here instead of string.empty
			};
			t.RunWorkerCompleted += Finished;//BackgroundWorkerFinished(sender, e);
			t.RunWorkerAsync();
		}
		public void Finished(object sender, RunWorkerCompletedEventArgs e)
		{
			//result has been set, now what?
			
			
		}
    }
