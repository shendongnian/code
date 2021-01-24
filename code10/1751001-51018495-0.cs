    private void MainPage_Loaded(object sender, RoutedEventArgs e)
    {
        //Get current managed thread ID
        Debug.WriteLine(Environment.CurrentManagedThreadId);
        DispatcherTimer timer = new DispatcherTimer();
        timer.Interval = TimeSpan.FromMinutes(1);
        timer.Tick += async (ob, arg) =>
        {
            Debug.WriteLine( Environment.CurrentManagedThreadId);
            //You can update the booking room color here
            //TODO get data and update room color
    
            //You can also update the booking room color using Dispatcher.RunAsync method
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () => 
            {
                Debug.WriteLine(Environment.CurrentManagedThreadId);
                //TODO get data and update room color
            });
        };
        timer.Start();
    }
