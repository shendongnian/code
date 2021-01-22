    // here we declare the timer that this class will use.
    private Timer timer;
    
    //I've shown the timer creation inside the constructor of a main form,
    //but it may be done elsewhere depending on your needs
    public Main()
    {
         
       // other init stuff omitted
       
       timer = new Timer();     
       timer.Interval = 10000;  // 10 seconds between images
       timer.Tick += timer_Tick;   // attach the event handler (defined below)
    }
    
    
    void timer_Tick(object sender, EventArgs e)
    {
       // this is where you'd show your next image    
    }
