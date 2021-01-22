    public class Memento : IDisposable
    {
        private readonly Action action;
        public Memento(Action action)
        {
            if (action == null)
            {
                throw new ArgumentNullException("action");
            }
            this.action = action;
        }
        private Action Action
        {
            get
            {
                return this.action;
            }
        }
        private bool Disposed { get; set; }
        #region IDisposable Members
        public void Dispose()
        {
            if (this.Disposed)
            {
                throw new ObjectDisposedException("Memento");
            }
            this.Action();
            this.Disposed = true;
        }
        #endregion
