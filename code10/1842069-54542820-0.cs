    public class MyAppSettings : IAppSettings
    {
        private readonly ObjectCache _cache = MemoryCache.Default;
        private readonly object _lock = new Object();
        private KeyValueClient _kvClient;
        public string MySecretValue => GetString("MySecretValue");
        private KeyValueClient GetKeyVaultClient()
        {
            // Initialize _kvClient if required
            
            return _kvClient;
        }
        private string GetSecret(string name)
        {
            lock (_lock)
            {
                if (_cache.Contains(key))
                    return (string) _cache.Get(key);
                // Sanitize name if required, remove reserved chars
                // Get value from KV
                var value = ""; // value from KV
                // Cache it
                _cache.Set(name, value, DateTime.UtcNow.AddHours(1));
                return value;
            }
        }
    }
