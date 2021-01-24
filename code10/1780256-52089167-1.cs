    public class Page
    {
        private CancellationTokenSource cancellationTokenSource;
        
        public Page()
        {
            cancellationTokenSource = new CancellationTokenSource();
        }
        public void CallPoll()
        {
            PollCurrentHardwareStatus(cancellationTokenSource);
        }
        public void OnCancelPoll(object sender, EventArgs e)
        {
            cancellationTokenSource.Cancel();
        }
    }
