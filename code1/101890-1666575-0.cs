    if (appmode == "trial")
    {
      // If the FirstRunDate is MinValue, it's the first run, so set this value up
      if (Properties.Settings.Default.FirstRunDate == DateTime.MinValue)
      {
        Properties.Settings.Default.FirstRunDate = DateTime.Now;
        Properties.Settings.Default.Save(); 
      }
    
      // Now check whether 30 days have passed since the first run date
      if (Properties.Settings.Default.FirstRunDate.AddMonths(1) < DateTime.Now)
      {
        // Do whatever you want to do on expiry (exception message/shut down/etc.)
      }
    }
