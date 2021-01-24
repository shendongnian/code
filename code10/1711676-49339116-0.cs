    System.Timers.Timer t = new System.Timers.Timer();
    t.Elapsed += new ElapsedEventHandler(Work);
    t.Interval = 10;
    t.Enabled = true;
    
    private void Work(object sender, ElapsedEventArgs e)
    {
        //[Thread safety]
        if (!Dispatcher.CheckAccess())
        {
            Dispatcher.BeginInvoke((ElapsedEventHandler)Work, sender, e);
            return;
        }
    
        Task task = Task.Run(() =>
        {
            // Your non UI work
    
            Dispatcher.BeginInvoke((Action)delegate ()
            {
                // Your UI work
            });
        });
    }
