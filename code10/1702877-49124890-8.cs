    public sealed class VersionScope : IDisposable {
        private bool _isCompleted;
        private bool _isDisposed;
        private readonly bool _asyncFlow;
        // thread local versions
        private static readonly ThreadLocal<VersionChain> _tlVersions = new ThreadLocal<VersionChain>();
        // async local versions
        private static readonly AsyncLocal<VersionChain> _alVersions = new AsyncLocal<VersionChain>();
        // to get current version, first check async local storage, then thread local
        public static Version CurrentVersion => _alVersions.Value?.Current ?? _tlVersions.Value?.Current;
        // helper method
        private VersionChain CurrentVersionChain => _asyncFlow ? _alVersions.Value : _tlVersions.Value;
        public VersionScope(int version, bool asyncFlow = false) {
            _asyncFlow = asyncFlow;
            var cur = CurrentVersionChain;
            // remember previous versions if any
            if (asyncFlow) {
                _alVersions.Value = new VersionChain(new Version(version), cur);
            }
            else {
                _tlVersions.Value = new VersionChain(new Version(version), cur);
            }
        }
        public void Dispose() {
            if (_isCompleted || _isDisposed)
                return;
            var cur = CurrentVersionChain;
            if (cur != null) {
                DeleteVersion(cur.Current);
                // restore previous
                if (_asyncFlow) {
                    _alVersions.Value = cur.Previous;
                }
                else {
                    _tlVersions.Value = cur.Previous;
                }
            }
            _isDisposed = true;
        }
        public void Complete() {
            if (_isCompleted || _isDisposed)
                return;
            var cur = CurrentVersionChain;
            if (cur != null) {
                PushVersion(cur.Current);
                // restore previous
                if (_asyncFlow) {
                    _alVersions.Value = cur.Previous;
                }
                else {
                    _tlVersions.Value = cur.Previous;
                }
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
