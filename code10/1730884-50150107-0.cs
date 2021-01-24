    btnNewTimer.Click += (sender, e) =>
    {
        System.Timers.Timer aTimer = new System.Timers.Timer();
        aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        aTimer.Interval = 5000; //Miliseconds : 5000 = 1 sec
        aTimer.Enabled = true;
    };
    private void OnTimedEvent(object source, ElapsedEventArgs e)
    {
        editTimerInfo.Text = "Timer done!"; //Successfully enters the function in MainActivity.cs but won't set the EditText value
    }
