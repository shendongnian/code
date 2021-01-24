     public Your_Class_Name()
     {
        System.Windows.Threading.DispatcherTimer MyTimer = new System.Windows.Threading.DispatcherTimer();
        MyTimer.Tick += new EventHandler(Timer_Tick);
        MyTimer.Interval=1000;
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
