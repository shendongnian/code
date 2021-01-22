    System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
    t.Interval = 1000; // specify interval time as you want 
    t.Tick += new EventHandler(timer_Tick);
    t.Start();
    void timer_Tick(object sender, EventArgs e)
    {
      label1.text = DateTime.Now.ToString("h:mm:ss")); 
      Update(); //this will refresh the form and label's text is updated.
    }
