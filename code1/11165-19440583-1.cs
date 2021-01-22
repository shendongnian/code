    Timer timer = new Timer();
    timer.Callback += delegate
    {
        if (once) { timer.Enabled = false; }
        Callback.execute(callbackId, args);
    };
    timer.Enabled = true;
    timer.Interval = ms;
    timer.Start();
    Window.timers.Add(Environment.TickCount, timer);
