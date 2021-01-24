    private System.Threading.Timer timer;
    void StartTimer()
    {
        timer = new System.Threading.Timer(TimerExecution, null, TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(5));
    }
    void TimerExecution(object state)
    {
        try
		{
			//Check system status
		}
		catch (Exception e)
		{
			Console.WriteLine("An error occurred. Resuming on next loop...");
		}
    }
