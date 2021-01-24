c#
public class ButtonClicked
    {
        //make sure you've got the same instance on both methods
        private Loop loop = new Loop();
        protected async void OnAppearing()
        {
            //other work
            await loop.StartLoop();
        }
        protected void OnDisappearing()
        {
            //other work
            loop.StopLoop();
        }
    }
    public class Loop
    {
        private bool _continueChecking;
        private readonly TimeSpan interval = new TimeSpan(0,1,0);
        public async Task StartLoop()
        {
            await DoLoop();
        }
        public void StopLoop()
        {
            _continueChecking = false;
        }
        private async Task DoLoop()
        {
            _continueChecking = true;
            await Task.Factory.StartNew(() =>
            {
                System.Threading.Thread.Sleep(interval);
                TheWork();
            });
            if (_continueChecking)
            {
                DoLoop();
            }
        }
        private void TheWork()
        {
           //specific work stuff
           //can be anywhere so it is testable and reusable
        }
    }
