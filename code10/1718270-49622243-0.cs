     public Your_Class_Name()
     {
        System.Timers.Timer MyTimer = new System.Timers.Timer();
        MyTimer.Tick += new EventHandler(Timer_Tick);
        MyTimer.Interval=4000;
     }
     void Timer_Tick(object sender, EventArgs e)
     {
        someTextBox.Text += "Some text\n";
     }
     private void Button_Click(object sender, RoutedEventArgs e)
     {
         someTextBox.Clear();
         MyTimer.Start();
     }
