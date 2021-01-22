    public partial class Window1 : Window
    {
        Thread _worker;
        public Window1()
        {
            InitializeComponent();
            _worker = new Thread(new ThreadStart(this.DoWork));
            _worker.Start();
        }
        private void DoWork()
        {
            WorkObject tWorker = new WorkObject((MyUpdateDelegate)delegate (int count) { this.UpdateCount(count); } , 0);
            tWorker.StartProcessing();
        }
        public delegate void MyUpdateDelegate (int count);
        private void UpdateCount(int currentCount)
        {
            if (Dispatcher.CheckAccess())
            {
                lblcounter.Content = currentCount;
            }
            else
            {
                lblcounter.Dispatcher.Invoke((MyUpdateDelegate)delegate (int count)
                {
                    this.UpdateCount(count); 
                }, currentCount);
            }
        }
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            if (_worker != null)
            {
                _worker.Abort();
            }
            base.OnClosing(e);
        }
    }
    public class WorkObject
    {
        private Window1.MyUpdateDelegate _callback;
        private int _currentCount;
        public WorkObject(Window1.MyUpdateDelegate callback, int count)
        {
            _callback = callback;
            _currentCount = count;
        }
        public void StartProcessing()
        {
            for (int i = 0; i < 100000; i++)
            {
                _currentCount++;
                if (_callback != null)
                {
                    _callback(_currentCount);
                    Thread.Sleep(100);
                }
            }
        }
    }
