    overrides OnLoad(...)
    {
       /* Using a timer will let the splash screen load and display itself before
          calling this handler
       */
       timer.Interval = 1;
       timer.Tick += delegate {
         if (SplashFormInitialized != null) SplashFormInitialized(this, EventArgs.Empty);
       };
       timer.Enabled = true; 
    }
