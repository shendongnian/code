	public abstract class AsyncCommand : ICommand
	{
		public event EventHandler CanExecuteChanged;
		public event EventHandler RunWorkerStarting;
		public event RunWorkerCompletedEventHandler RunWorkerCompleted;
		public abstract string Text { get; }
		private bool _isExecuting;
		public bool IsExecuting
		{
			get { return _isExecuting; }
			private set
			{
				_isExecuting = value;
				if (CanExecuteChanged != null)
					CanExecuteChanged(this, EventArgs.Empty);
			}
		}
		protected abstract void OnExecute(object parameter);
		public void Execute(object parameter)
		{	
			try
			{	
				onRunWorkerStarting();
				var worker = new BackgroundWorker();
				worker.DoWork += ((sender, e) => OnExecute(e.Argument));
				worker.RunWorkerCompleted += ((sender, e) => onRunWorkerCompleted(e));
				worker.RunWorkerAsync(parameter);
			}
			catch (Exception ex)
			{
				onRunWorkerCompleted(new RunWorkerCompletedEventArgs(null, ex, true));
			}
		}
		private void onRunWorkerStarting()
		{
			IsExecuting = true;
			if (RunWorkerStarting != null)
				RunWorkerStarting(this, EventArgs.Empty);
		}
		private void onRunWorkerCompleted(RunWorkerCompletedEventArgs e)
		{
			IsExecuting = false;
			if (RunWorkerCompleted != null)
				RunWorkerCompleted(this, e);
		}
		public virtual bool CanExecute(object parameter)
		{
			return !IsExecuting;
		}
	}
