    public class BusyState
    {
        private int isBusy;
        public void SignalTaskStarted()
        {
            Interlocked.Increment(ref isBusy);
        }
        public void SignalTaskFinished()
        {
            if (Interlocked.Decrement(ref isBusy) < 0)
            {
                throw new InvalidOperationException("No tasks started.");
            }
        }
        public bool IsBusy()
        {
            return Thread.VolatileRead(ref isBusy) > 0;
        }
    }
    public class BusinessObject
    {
        private readonly BusyState busyState = new BusyState();
        public void Save()
        {
            //Raise a "Started" event to disable UI controls...
            //Start a few async tasks which call CallbackFromAsyncTask when finished.
            //Start task 1
            busyState.SignalTaskStarted();
            //Start task 2
            busyState.SignalTaskStarted();
            //Start task 3
            busyState.SignalTaskStarted();
        }
        
        private void CallbackFromAsyncTask()
        {
            busyState.SignalTaskFinished();
            if (!busyState.IsBusy())
            {
                //Raise a "Completed" event to enable UI controls...
            }
        }
    }
