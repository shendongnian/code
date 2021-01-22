    System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
    dispatcherTimer.Tick += dispatcherTimer_Tick;
    dispatcherTimer.Interval = new TimeSpan(0,0,0,0,10); // Control animation speed / how often the tick will be called.
    dispatcherTimer.Start();
    private void dispatcherTimer_Tick(object sender, EventArgs e)
    {
         if ( this.Width < 500 )
         {
               this.Width += 10;
         } 
         else 
         {
               DispatcherTimer timer = (DispatcherTimer)sender;
               timer.Stop();
         }
    }
