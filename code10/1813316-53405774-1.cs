    DateTime endTime = new DateTime(2018, 11, 21, 12, 31, 0);
    public void StartCountDownTimer()
    {
       timer = new System.Timers.Timer();
       timer.Interval = 1000;
       timer.Elapsed += t_Tick;
       TimeSpan ts = endTime - DateTime.Now;
       cTimer = ts.ToString("d' Days 'h' Hours 'm' Minutes 's' Seconds'");
       timer.Start();
    }
    string cTimer;
    System.Timers.Timer timer;
    void t_Tick(object sender, EventArgs e)
    {
       TimeSpan ts = endTime - DateTime.Now;
       cTimer = ts.ToString("d' Days 'h' Hours 'm' Minutes 's' Seconds'");
       if ((ts.TotalMilliseconds < 0) || (ts.TotalMilliseconds < 1000))
       {
          timer.Stop();
       }
    }
