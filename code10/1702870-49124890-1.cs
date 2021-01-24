    public sealed class VersionScope : IDisposable {
        private bool _isCompleted;
        private bool _isDisposed;
        // note ThreadStatic attribute
        [ThreadStatic] private static Version _currentVersion;
        public static Version CurrentVersion => _currentVersion;
        public VersionScope(int version) {
            _currentVersion = new Version(version);
        }
        public void Dispose() {
            if (_isCompleted || _isDisposed)
                return;
            var v = _currentVersion;
            if (v != null) {
                DeleteVersion(v);
            }
            _currentVersion = null;
            _isDisposed = true;
        }
        public void Complete() {
            if (_isCompleted || _isDisposed)
                return;
            var v = _currentVersion;
            if (v != null) {
                PushVersion(v);
            }
            _currentVersion = null;
            _isCompleted = true;
        }
        private void DeleteVersion(Version version) {
            Console.WriteLine($"Version {version} deleted");
        }
        private void PushVersion(Version version) {
            Console.WriteLine($"Version {version} pushed");
        }
    }
