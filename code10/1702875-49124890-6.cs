    public sealed class VersionScope : IDisposable {
        private bool _isCompleted;
        private bool _isDisposed;
        private static readonly ThreadLocal<VersionChain> _versions = new ThreadLocal<VersionChain>();
        public static Version CurrentVersion => _versions.Value?.Current;
        public VersionScope(int version) {
            var cur = _versions.Value;
            // remember previous versions if any
            _versions.Value = new VersionChain(new Version(version), cur);
        }
        public void Dispose() {
            if (_isCompleted || _isDisposed)
                return;
            var cur = _versions.Value;
            if (cur != null) {
                DeleteVersion(cur.Current);
                // restore previous
                _versions.Value = cur.Previous;
            }
            _isDisposed = true;
        }
        public void Complete() {
            if (_isCompleted || _isDisposed)
                return;
            var cur = _versions.Value;
            if (cur != null) {
                PushVersion(cur.Current);
                // restore previous
                _versions.Value = cur.Previous;
            }
            _isCompleted = true;
        }
        private void DeleteVersion(Version version) {
            Console.WriteLine($"Version {version} deleted");
        }
        private void PushVersion(Version version) {
            Console.WriteLine($"Version {version} pushed");
        }
        // just a class to store previous versions
        private class VersionChain {
            public VersionChain(Version current, VersionChain previous) {
                Current = current;
                Previous = previous;
            }
            public Version Current { get; }
            public VersionChain Previous { get; }
        }
    }
