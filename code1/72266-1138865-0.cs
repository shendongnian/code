	public static void RunAsync(this Action ActionToAsync, Action<object, RunWorkerCompletedEventArgs> FinishedAction)
		{
			var t = new BackgroundWorker();
			t.DoWork += (sender, e) => ActionToAsync();
			t.RunWorkerCompleted += (sender, e) => FinishedAction.Invoke(sender,e);//BackgroundWorkerFinished(sender, e);
			t.RunWorkerAsync();
		}
