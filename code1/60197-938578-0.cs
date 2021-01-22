    private System.Windows.Threading.DispatcherTimer popupTimer;
    private void OnClick(object sender, RoutedEventArgs e)
    {
        popupTimer = new System.Windows.Threading.DispatcherTimer();
        
        // Work out interval as time you want to popup - current time
        popupTimer.Interval = specificTime - DateTime.Now;
        popupTimer.IsEnabled = true;
        popupTimer.Tick += new EventHandler(popupTimer_Tick);
    }
    
    void popupTimer_Tick(object sender, EventArgs e)
    {
        TimerClock.IsEnabled = false;
        // Show popup
        // ......
    }
