    interface IMainView
    {
        void Init(PleaseWaitViewModel viewModel);
        void ShowDialog();
        void Close();
    }
    public class MainViewModel
    {
         private IMainView _view;
         public MainViewModel(IMainView view)
         {
             _view = view;
            backgroundWorker = new BackgroundWorker() { WorkerSupportsCancellation = true };
            backgroundWorker.DoWork += BackgroundWorker_DoWork;
            backgroundWorker.RunWorkerCompleted += 
            BackgroundWorker_RunWorkerCompleted;
            var pleaseWaitViewModel = new PleaseWaitViewModel(backgroundWorker);
            _view.Init(pleaseWaitViewModel);
         }
        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        _view.Close();
    }
    private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
    {
        // Some work
        Thread.Sleep(5000);
    }
    private void DoSomethingImpl(object parameter)
    {
        _view.ShowDialog();
    }
    }
