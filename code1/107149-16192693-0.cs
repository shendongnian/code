            public List<string> SearchKeys(string searchTerm)
            {
                var keys = ConfigurationManager.AppSettings.Keys;
                return keys.Cast<object>()
                           .Where(key => key.ToString().ToLower()
                           .Contains(searchTerm.ToLower()))
                           .Select(key => ConfigurationManager.AppSettings.Get(key.ToString())).ToList();
            }
