    public abstract class BotTask
    {
        private bool Running { get; set; }
        public CancellationToken Token => _tokenSource.Token;
        private CancellationTokenSource _tokenSource;
        public abstract void Start();
        protected void InternalStart(Action job)
        {
            _tokenSource = new CancellationTokenSource();
            Running = true;
            job();
            Running = false;
        }
    }
    public class CustomTask : BotTask
    {
        public override void Start()
        {
            InternalStart(MyJob);
        }
    }
