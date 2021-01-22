    public class APITask
    {
        private uint _osThreadId;
        public void Run()
        {
            _osThreadId = GetCurrentThreadID();
            API.RunBlockingMethod();
        }
        
        public void Cancel()
        {
            API.CancelBlockingCall(_osThreadId);
        }
    }
