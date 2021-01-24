    private DateTime _startTime; //track the start time
    private DispatcherTimer tPOI;
    
    private void button12_Click(object sender, RoutedEventArgs e) 
    {
        tPOI = new DispatcherTimer();
        tPOI.Tick += new System.EventHandler(dispatcherTimer_TickPOI);
        tPOI.Interval = new TimeSpan(0, 0, 10);
    
        _startTime = DateTime.Now; //assign start time when it actually starts
    
        tPOI.Start();
        MessageBox.Show("recording POI");
    }
    
    private void dispatcherTimer_TickPOI(object sender, EventArgs e) 
    {
         if (_startTime.AddMinutes(10) > DateTime.Now) //check if it has crossed 10 mins
         { 
            tPOI.Stop();
         } 
         else 
         {
             using(StreamWriter file = new StreamWriter(@textBox36.Text, true)) 
             {
                 file.WriteLine("pos POI");
                 file.WriteLine(textBox40.Text);
                 file.WriteLine(textBox41.Text);
                 file.WriteLine(textBox42.Text);
                 file.WriteLine(textBox46.Text);
             }
         }
    }
