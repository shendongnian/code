		private void UpdateProgress(int percent)
		{
			RunOnUiThread(() => _myProgressBar.Value = percent);
		}
		private void RunOnUiThread(Action action)
		{
			if (InvokeRequired)
			{
				Invoke(action);
			}
			else
			{
				action();
			}
		}
