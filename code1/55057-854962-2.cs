using System.Windows.Forms;
namespace UI.Windows.Forms.Utilities.DataManagment
{
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
}
    
And here is the usage. One thing to note is that it exposes a static property ControlInvoker that needs to be set only once (you should do it at the beginning of the app load)
Let's take the same example that I posted in question and re write it
DataLoader loader = new DataLoader();
loader.ControlInvoker.Parent = this; // needed to be set only once
private void StartButton_Click(object sender, EventArgs e)
{
    
    Thread thread1 = new Thread(new ThreadStart(PerformWorkerTask));
    _worker = new BackgroundWorker();
    thread1.Start();
}
public void PerformWorkerTask()
{
    
            loader.WorkDelegate = delegate { 
                                             // get any data you want 
                                             for (int i = 0; i < 10; i++)
                                            {
                                                Thread.Sleep(100);
                                            }
                                           };
            loader.WorkCompleted = delegate
                                       {
                                           // access any control you want 
                                           MessageLabel.Text = "Completed";
                                            
                                       };
            loader.Execute();
 }
Cheers
