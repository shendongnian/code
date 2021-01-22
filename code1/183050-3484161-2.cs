    public class MyForm : Form
    {
        private OutputControl outputControl;
        
        public void btnClick(...)
        {
            // Start a long running process that gives feedback to UI.
            var process = new LongRunningProcess(this, outputControl);
            ThreadPool.QueueUserWorkItem(process.DoWork);
        }
    }
    class LongRunningProcess
    {
        // Needs a reference to the interface that marshals calls back to the UI
        // thread and some control that needs updating.
        public LongRunningProcess(ISynchonizeInvoke invoker,
                                  OutputControl outputControl)
        {
            this.invoker = invoker;
            this.outputControl = outputControl;
        }
        public void DoWork(object state)
        {
            // Do long-running job and report progress.
            invoker.Invoke(outputControl.Update(...));
        }
    }
