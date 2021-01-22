    public class DataLoader
    {
        private BackgroundWorker _worker;
        private DoWorkEventHandler _workDelegate;
        private RunWorkerCompletedEventHandler _workCompleted;
        private ExceptionHandlerDelegate _exceptionHandler;
        public static readonly Control ControlInvoker = new Control();
        public DoWorkEventHandler WorkDelegate
        {
            get { return _workDelegate; }
            set { _workDelegate = value; }
        }
        public RunWorkerCompletedEventHandler WorkCompleted
        {
            get { return _workCompleted; }
            set { _workCompleted = value; }
        }
        public ExceptionHandlerDelegate ExceptionHandler
        {
            get { return _exceptionHandler; }
            set { _exceptionHandler = value; }
        }
        public void Execute()
        {
            if (WorkDelegate == null)
            {
                throw new Exception(
                    "WorkDelegage is not assinged any method to execute. Use WorkDelegate Property to assing the method to execute");
            }
            if (WorkCompleted == null)
            {
                throw new Exception(
                    "WorkCompleted is not assinged any method to execute. Use WorkCompleted Property to assing the method to execute");
            }
            SetupWorkerThread();
            _worker.RunWorkerAsync();
        }
        private void SetupWorkerThread()
        {
            _worker = new BackgroundWorker();
            _worker.WorkerSupportsCancellation = true;
            _worker.DoWork += WorkDelegate;
            _worker.RunWorkerCompleted += worker_RunWorkerCompleted;
        }
        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(e.Error !=null && ExceptionHandler != null)
            {
                ExceptionHandler(e.Error);
                return;
            }
            ControlInvoker.Invoke(WorkCompleted, this, e);
        }
    }
