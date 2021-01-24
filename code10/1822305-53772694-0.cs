    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var provider = new SimpleModelBinderProvider(
                typeof(IEnumerable<int>), new CommaDelimitedArrayBinder ());
            config.Services.Insert(typeof(ModelBinderProvider), 0, provider);
        }
    }
