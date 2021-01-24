    private System.Timers.Timer Timer = null;
    private double TimerDelay = 30d * 1000d; // 30 seconds
    private void StartTimer()
    {
        Timer = new System.Timers.Timer() { Interval = TimerDelay , AutoReset = false};
        Timer.Elapsed += Timer_Elapsed;
        Timer.Start();
    } 
    private void StopTimer()
    {
        Timer.Stop();
    }     
    private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
        // stop the timer
        StopTimer();
        // call the method to make the player lose and end the game
        EndGame();                
    }  
