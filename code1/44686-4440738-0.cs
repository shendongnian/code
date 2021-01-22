            T val = _client.Get<T>(key);
            if (val == null)
            {
                // ... filling val variable ...
                var result = _client.Store(StoreMode.Add, key, val);
                // ... result can be false, sometimes ...
            }
