    Timer timer { get; set; }
     
     void Start () 
     {
         timer = new Timer();
         timer.Interval = Timespan.FromMilliseconds(100);
         timer.Elapsed +=TimerTick;
 
         timer.Start();
 
     }
     
     void TimerTick(object o, EventArgs e)
     {
         MovementBehaviour?.PerformMovement(this); 
     }
