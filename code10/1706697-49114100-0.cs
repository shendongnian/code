        //Reference
        using System.Windows.Timers;
        
        //Toggle Button Click Event
        private void button_Click(object sender, RoutedEventArgs e)
        {
            button.IsChecked = true;
            //Create New DispatcherTimer
            DispatcherTimer dst = new DispatcherTimer();
            dst.Interval = new TimeSpan(0, 0, 1);  //Set Interval to 1 second.       
            dst.Tick += Dst_Tick;                   
            dst.Start(); //Start Timer  
        }
        
        //Timer Elapsed Event
        private void Dst_Tick(object sender, EventArgs e)
        {
            DispatcherTimer t = (DispatcherTimer)sender; //Grab the DispatcherTimer
            t.Stop(); //Stop the timer or it will keep looping
            button.IsChecked = false; //Reset the ToggleButton          
        }
