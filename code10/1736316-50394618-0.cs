    private readonly CancellationTokenSource _shutDown = new CancellationTokenSource();
    public WindowName()
    {
    	this.Closed =+ (s, e) => this._shutDown.Cancel();
    }
    private void SongChange(object sender, RoutedEventArgs e)
    {
    	SongChangeAction();
    	songLength = (int)BGMPlayer.NaturalDuration.TimeSpan.TotalSeconds;
    	songProgress = Task.Factory.StartNew(SongProgressUpdate, this._shutDown.Token, TaskCreationOptions.LongRunning, TaskScheduler.Default);
    }
    private void SongProgressUpdate()
    {
    	while (!this._shutDown.IsCancellationRequested)
    	{
    		Dispatcher.Invoke(() => { workingResources.SongProgress = BGMPlayer.Position.TotalSeconds / songLength * 100; });
    		Thread.Sleep(1000);
    	}
    }
