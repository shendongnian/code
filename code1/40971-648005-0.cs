    public class RepeatingTask
    {
        public MyObjectState _objectState;
    
        public RepeatingTask(Timespan interval)
        {
           Timer timer=new Timer(Timer_Tick); //This assumes we pass a delegate. Each timer is different. Refer to MSDN for proper usage
           timer.Interval=interval;
           timer.Start();
    
        }
        private DateTime _lastFire;
        private void Timer_Tick()
        {
           
           Update(DateTime.Now().Subtract(_lastFire); // Get the elapsed time since interval won't be exact. You could also use ticks or however you want to break time down.
           _lastFire=DateTime.Now(); //Store when we last fired...
        }
    
    }
