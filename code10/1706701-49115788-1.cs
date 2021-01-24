        using System;
        using System.Windows;
        using System.Windows.Threading;
     ....
        private int value = 0;
        private void _toggle_Click(object sender, RoutedEventArgs e)
        {
            _toggle.IsChecked = true;
            //Create New DispatcherTimer
            DispatcherTimer dst = new DispatcherTimer();
            dst.Interval = new TimeSpan(0, 0, 1);  //Set Interval to 1 second.       
            dst.Tick += Dst_Tick;
            dst.Start(); //Start Timer  
            value++;
            _value.Text = value.ToString();
        }
        //Timer Elapsed Event
        private void Dst_Tick(object sender, EventArgs e)
        {
            DispatcherTimer t = (DispatcherTimer)sender; //Grab the DispatcherTimer
            t.Stop(); //Stop the timer or it will keep looping
            _toggle.IsChecked = false; //Reset the ToggleButton    
            value--;
            _value.Text = value.ToString();
        }
