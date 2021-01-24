        public void init()
        {
            _urlService = customConfig["DemoUrlService"];
      //      onStart();
            aTimer = new Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = Convert.ToDouble(getIntervialTimeIntervalTime());
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }
