    public class Suspend : IDisposable
    { 
        private Timer timerRef;
        public Suspend(Timer timer)
        {   
            timerRef = timer
            timer.Stop();
        }
        public void Dispose()
        {
            timerRef.Start();
            //note we don't actually want to dispose the timer here
        }
    }
    using(var s = new Suspend(myTimer)
    {
        //do stuff
    }
