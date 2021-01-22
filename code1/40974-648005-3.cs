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
           DateTime curTime=DateTime.Now();
           DateTime timeSinceLastFire = curTime-lastFireTime;
           _lastFire=DateTime.Now(); //Store when we last fired...
           accumulatedtime+=timeSinceLastFire
           while(accumulatedtime>=physicsInterval)
           {
              Update(physicsInterval);
              accumulated-=physicInterval;
           }
                   }
    
    }
