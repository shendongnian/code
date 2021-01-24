    public static class Resources
    {
        private static ResourceManager _resourceManager;
        public static string GetString(string resourceKey)
        {
            if (_resourceManager != null)
            {
                return _resourceManager.GetString(resourceKey);
            }
    #if DEBUG
            const string configuration = "Debug";
    #else
            const string configuration = "Release";
    #endif
            _resourceManager = new ResourceManager($"StackOverflow.Text.{configuration}", typeof(Resources).Assembly);
            return _resourceManager.GetString(resourceKey);
        }
    }
