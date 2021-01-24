    dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
    dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
    dispatcherTimer.Interval = new TimeSpan(0,0,5);
    
    int RandomNumber;
    Random random = new Random();
    
    private void btn_click(object sender, RoutedEventArgs e)
    {
        if (thisStatus == false)
        {
           thisStatus = true;
           dispatcherTimer.Start();
        }
            else {
              thisStatus = false;
              dispatcherTimer.Stop();
             }
    }
    
    private void dispatcherTimer_Tick(object sender, EventArgs e)
    {
        RandomNumber = random.Next(0, 100);
    }
