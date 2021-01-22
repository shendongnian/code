    class Metronome
    {
        public event EventHandler Tick;
        protected virtual void OnTick(EventArgs e)
        {
            //Raise the Tick event (see below for an explanation of this)
            var tickEvent = Tick;
            if(tickEvent != null)
                tickEvent(this, e);
        }
        public void Go()
        {
            while(true)
            {
                Thread.Sleep(2000);
                OnTick(EventArgs.Empty); //Raises the Tick event
            }
        }
    }
