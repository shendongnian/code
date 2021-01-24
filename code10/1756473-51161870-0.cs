    public class BackgroundWorkerHelper
    {
        private static string _infoLabelText = string.Empty;
        public BackgroundWorker _BackgroundWorker;
        private BarEditItem _marqueeInfo;//this is marquee progress bar
        public BackgroundWorkerHelper(BarEditItem marqueeInfo)
        {
            _marqueeInfo = marqueeInfo;
            _BackgroundWorker = new BackgroundWorker();
            _BackgroundWorker.WorkerReportsProgress = true;
            _BackgroundWorker.WorkerSupportsCancellation = true;
            _BackgroundWorker.DoWork += backgroundWorker_DoWork;
            _BackgroundWorker.ProgressChanged += backgroundWorker_ProgressChanged;
            _BackgroundWorker.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;
        }
        public void Run(string labelText, int imageIndex)
        {
            _marqueeInfo.Caption = labelText;
            _marqueeInfo.ImageIndex = imageIndex;
            if (!_BackgroundWorker.IsBusy)
                _BackgroundWorker.RunWorkerAsync();
            else
                _marqueeInfo.Caption = "Busy processing saving data, please wait...";
        }
        public void DoWork()
        {
            for (int i = 0; i <= 5; i++)
            {
                _BackgroundWorker.ReportProgress(i); // call backgroundWorker_ProgressChanged event and pass i (which is e argument e.ProgressPercentage) to update UI controls
                Thread.Sleep(250);
            }
        }
        public void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            _marqueeInfo.Visibility = BarItemVisibility.Always;
        }
        public void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _marqueeInfo.Visibility = BarItemVisibility.Never;
        }
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            DoWork();
        }
        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgressChanged(sender, e);
        }
        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            RunWorkerCompleted(sender, e);
        }
