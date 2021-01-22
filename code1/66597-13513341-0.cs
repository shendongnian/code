    if (!active)
            {
                myTimer= new System.Threading.Timer(new TimerCallback(TimerProc));
            }
            myTimer.Change(10000, 0);
            active = true;
    private void TimerProc(object state)
        {
            // The state object is the Timer object.
            System.Threading.Timer t = (System.Threading.Timer)state;
            t.Dispose();
            Console.WriteLine("The timer callback executes.");
            active = false;
            //action to do when timer is back to zero
        }
