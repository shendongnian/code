     TimeSpan timeBetween = DateTime.Today.AddDays(1) - DateTime.Now;
     System.Timers.Timer t = new System.Timers.Timer();
     t.Elapsed += new System.Timers.ElapsedEventHandler(t_Elapsed);
     t.Interval = 1000 * timeBetween.Seconds;
     t.Start();
