    class Test : IDisposable {
        public void Close() {
            // Frees up resources
        }
        void IDisposable.Dispose() {
            Close();
        }
    }
