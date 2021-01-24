		private void button1_Click_1(object sender, EventArgs e)
		{
			if (_thread == null)
			{
				_thread = new Thread(new ThreadStart(BackgroundThread));
				_thread.IsBackground = true;
				_thread.Start();
			}
		}
		private void BackgroundThread()
		{
			UpdateProgress(0);
			ClearCache();
			UpdateProgress(25);
			ClearCookie();
			UpdateProgress(50);
			ClearHistory();
			UpdateProgress(75);
			TempCleaner();
			UpdateProgress(100);
		}
