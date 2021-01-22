    public class MyClass
    {
        System.Threading.Timer Timer;
        System.DateTime StopTime;
        public void Run()
        {
            StopTime = System.DateTime.Now.AddMinutes(10);
            Timer = new System.Threading.Timer(TimerCallback, null, 0, 5000);
        }
    	
        private void TimerCallback(object state)
        {
            if(System.DateTime.Now >= StopTime)
            {
                Timer.Dispose();
                return;
            }
            // Do your work...
        }
    }
