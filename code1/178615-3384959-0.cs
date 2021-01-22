		private void myBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			// Set your sites dynamically here.
			string[] sites = new string[]
			{
				"Test.com",
				"Example.net",
				"Google.com"
			};
			myBackgroundWorker.ReportProgress(0, sites);
		}
		private void myBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			string[] sites = (string[])e.UserState;
			// Enjoy your string array.
		}
