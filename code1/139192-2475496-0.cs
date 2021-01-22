    System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
    timer.Enabled = true;
    timer.Interval = 1000; 
    timer.Tick += new EventHandler(timer_Tick); 
            void timer_Tick(object sender, EventArgs e)
            {
    //do something
            }
