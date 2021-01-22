    class DisposeHelper : IDisposable {
        private Action OnDispose { get; set; }
        public DisposeHelper(Action onDispose) {
            this.OnDispose = onDispose;
        }
        public void Dispose() {
            if (this.OnDispose != null) this.OnDispose();
        }
    }
