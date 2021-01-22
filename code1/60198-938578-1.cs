    private System.Windows.Threading.DispatcherTimer popupTimer;
    // Whatever is going to start the timer - I've used a click event
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
        popupTimer.IsEnabled = false;
        // Show popup
        // ......
    }
