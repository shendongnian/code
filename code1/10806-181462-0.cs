    public class ExceptionEventArgs : EventArgs
    {
        private readonly Exception error;
 
        public ExceptionEventArgs(Exception error)
        {
             this.error = error;
        }
        public Error
        {
             get { return error; }
        }
    }
    public class Computer
    {
        public event EventHandler Started = delegate{};
        public event EventHandler Stopped = delegate{};
        public event EventHandler Reset = delegate{};
        public event EventHandler<ExceptionEventArgs> Error = delegate{};
        protected void OnStarted()
        {
            Started(this, EventArgs.Empty);
        }
        protected void OnStopped()
        {
            Stopped(this, EventArgs.Empty);
        }
        protected void OnReset()
        {
            Reset(this, EventArgs.Empty);
        }
        protected void OnError(Exception e)
        {
            Error(this, new ExceptionEventArgs(e));
        }
    }
