    public sealed class Memento : IDisposable
    {
        private bool Disposed { get; set; }
        private Action Action { get; set; }
        public Memento(Action action)
        {
            if (action == null)
                throw new ArgumentNullException("action");
            Action = action;
        }
        void IDisposable.Dispose()
        {
            if (Disposed)
                throw new ObjectDisposedException("Memento");
            Action();
            Disposed = true;
        }
    }
