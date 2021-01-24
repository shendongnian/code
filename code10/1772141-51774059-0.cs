	private System.Threading.Timer _timer;
	public void StartResumeTimer()
	{
	  if(_timer == null)
		_timer = new System.Threading.Timer(async (e) => await DoWorkAsync(e), null, 0, 5000);
	}
	public void StopPauseTimer()
	{
	  _timer?.Dispose();
	  _timer = null;
	}
	public async Task DoWorkAsync(object state)
	{
	   await Task.Delay(500); // do some work here, Task.Delay is just something to make the code compile
	}
