    public class MyClass
    {
        private bool dataIsReady = false;
        private object locker = new object();
        BackgroundWorker worker;
        public void Begin()
        {
            worker = new BackgroundWorker();
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
        }
        public void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lock (locker)
            {
                dataIsReady = true;
            }
        }
        public void UseTriesToUseData()
        {
            lock (locker)
            {
                if (dataIsReady)
                {
                    DoStuff();
                }
                else
                {
                    this.worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(DoStuffCaller);
                }
            }
        }
        private void DoStuff()
        {
            // Do stuff with data.
        }
        private void DoStuffCaller(object sender, RunWorkerCompletedEventArgs e)
        {
            this.DoStuff();
        }
    }
