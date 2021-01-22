    System.Timers.Timer Timer = new System.Timers.Timer();
    Timer.Elapsed += new ElapsedEventHandler(KillZombies);
    Timer.Interval = 60000;
    Timer.Start()
    private void KillZombies(object source, ElapsedEventArgs e)
    {
        if((DateTime.Now - DateTime.Today) < new TimeSpan(0, 1, 0))
        {
            //ToDo: Kill Zombies
        }
    }
