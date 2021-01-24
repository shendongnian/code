    public class Resources
    {
        private readonly ResourceManager _resourceManager;
        public Resources()
        {
    #if DEBUG
            const string configuration = "Debug";
    #else
            const string configuration = "Release";
    #endif
            _resourceManager = new ResourceManager($"StackOverflow.Text.{configuration}", typeof(Resources).Assembly);
        }
        public string GetString(string resourceKey)
        {
            return _resourceManager.GetString(resourceKey);
        }
    }
