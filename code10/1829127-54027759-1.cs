    public static class FilterConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Filters.Add(new ModelStateValidationAttribute());
        }
    }
