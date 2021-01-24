    public class Page
    {
        private CancellationTokenSource cancellationTokenSource;
        
        public Page()
        {
            cancellationTokenSource = new CancellationTokenSource();
        }
        public async void CallPoll()
        {
            await PollCurrentHardwareStatus(cancellationTokenSource);
        }
        public void OnCancelPoll(object sender, EventArgs e)
        {
            cancellationTokenSource.Cancel();
        }
    }
