	public class MyViewModel : ViewModel
	{
		private readonly BackgroundWorker worker;
		private readonly ICommand instigateWorkCommand;
		private int currentProgress;
		
		public MyViewModel()
		{
			this.instigateWorkCommand = new DelegateCommand(o => this.worker.RunWorkerAsync(), o => !this.worker.IsBusy);
			
			this.worker = new BackgroundWorker();
			this.worker.DoWork += this.DoWork;
			this.worker.ProgressChanged += this.ProgressChanged;
		}
		
		// your UI binds to this command in order to kick off the work
		public ICommand InstigateWorkCommand
		{
			get { return this.instigateWorkCommand; }
		}
		
		public int CurrentProgress
		{
			get { return this.currentProgress; }
			private set
			{
				if (this.currentProgress != value)
				{
					this.currentProgress = value;
					this.OnPropertyChanged(() => this.CurrentProgress);
				}
			}
		}
		private void DoWork(object sender, DoWorkEventArgs e)
		{
			// do time-consuming work here, calling ReportProgress as and when you can
		}
		private void ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			this.CurrentProgress = e.ProgressPercentage;
		}
	}
