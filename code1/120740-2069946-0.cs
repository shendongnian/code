    public class CancellationToken
    {
        private volatile bool cancelled;
        public bool IsCancelled { get { return cancelled; } }
        public void Cancel() { cancelled = true; }
    }
