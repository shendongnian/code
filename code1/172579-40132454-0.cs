    public void RestartApp()
        {
            AppRestart = AppRestart.AddHours( 5 );
            AppRestart = AppRestart.AddMinutes( 30 );
            DateTime current = DateTime.Now;
            if (current > AppRestart) { AppRestart = AppRestart.AddDays( 1 ); }
            TimeSpan UntilRestart = AppRestart - current;
            int MSUntilRestart = Convert.ToInt32(UntilRestart.TotalMilliseconds);
            tmrRestart.Interval = MSUntilRestart;
            tmrRestart.Elapsed += tmrRestart_Elapsed;
            tmrRestart.Start();
        }
