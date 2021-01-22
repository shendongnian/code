    public class Foo : IDisposable
    {
        private event EventHandler _statusChanged;
        public event EventHandler StatusChanged
        {
            add
            {
                _statusChanged += value;
            }
            remove
            {
                _statusChanged -= value;
            }
        }
    
        public void Dispose()
        {
            _statusChanged = null;
        }
    }
