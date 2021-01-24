    public class CustomJsonConfigurationProvider : JsonConfigurationProvider
    {
        public CustomJsonConfigurationProvider(JsonConfigurationSource source) : base(source) { }
    
        public override void Load()
        {
            base.Load();
            foreach (string key in Data.Keys)
            {
                string[] keyParts = key.Split(new[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                ConfigurationManager.AppSettings.Set(keyParts[keyParts.Length - 1], Data[key]);
            }
        }
    }
    public class CustomJsonConfigurationSource : JsonConfigurationSource
    {
        public override IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            FileProvider = FileProvider ?? builder.GetFileProvider();
            return new CustomJsonConfigurationProvider(this);
        }
    }
    public static class CustomConfiguratorExtensions
    {
        public static IConfigurationBuilder AddCustomJsonFile(this IConfigurationBuilder builder, string path)
        {
            return AddCustomJsonFile(builder, provider: null, path: path, optional: false, reloadOnChange: false);
        }
    
        public static IConfigurationBuilder AddCustomJsonFile(this IConfigurationBuilder builder, string path, bool optional)
        {
            return AddCustomJsonFile(builder, provider: null, path: path, optional: optional, reloadOnChange: false);
        }
    
        public static IConfigurationBuilder AddCustomJsonFile(this IConfigurationBuilder builder, string path, bool optional, bool reloadOnChange)
        {
            return AddCustomJsonFile(builder, provider: null, path: path, optional: optional, reloadOnChange: reloadOnChange);
        }
    
        public static IConfigurationBuilder AddCustomJsonFile(this IConfigurationBuilder builder, IFileProvider provider, string path, bool optional, bool reloadOnChange)
        {
            if (provider == null && Path.IsPathRooted(path))
            {
                provider = new PhysicalFileProvider(Path.GetDirectoryName(path));
                path = Path.GetFileName(path);
            }
    
            var source = new CustomJsonConfigurationSource
            {
                FileProvider = provider,
                Path = path,
                Optional = optional,
                ReloadOnChange = reloadOnChange
            };
    
            builder.Add(source);
    
            return builder;
        }
    }
