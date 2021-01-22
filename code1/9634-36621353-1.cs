    class Lock : IDisposable
        {
            private static readonly Dictionary<string, string> Lockedkeys = new Dictionary<string, string>();
            private static readonly object CritialLock = new object();
            private readonly string _key;
            private bool _isLocked;
            public Lock(string key)
            {
                _key = key;
                lock (CritialLock)
                {
                    //if the dictionary doesnt contain the key add it
                    if (!Lockedkeys.ContainsKey(key))
                    {
                        Lockedkeys.Add(key, String.Copy(key)); //enusre that the two objects have different references
                    }
                }
            }
            public string GetLock()
            {
                var key = Lockedkeys[_key];
                if (!_isLocked)
                {
                    Monitor.Enter(key);
                }
                _isLocked = true;
                return key;
            }
            public void Dispose()
            {
                var key = Lockedkeys[_key];
                if (_isLocked)
                {
                    Monitor.Exit(key);
                }
                _isLocked = false;
            }
        }
