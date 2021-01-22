    public static class ResourceHelper
    {
        const string RESOURCE_EXTENSION = "resx";
        const string DEFAULT_CULTUREKEY = "(default)";
        public static string GetString(this IDictionary<string, XDocument> resource, string resourceKey)
        {
            return resource.GetString(resourceKey, System.Threading.Thread.CurrentThread.CurrentUICulture.Name);
        }
        public static string GetString(this IDictionary<string, XDocument> resource, string resourceKey, string cultureName)
        {
            if (resource.Count == 0)
                resource.LoadResource();
            // retrieve data
        }
        public static void LoadResource(this IDictionary<string, XDocument> resource)
        {
            // logic to load resource
        }
