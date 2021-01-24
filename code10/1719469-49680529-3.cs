    public static void Register(HttpConfiguration config)
    {
        config.MapHttpAttributeRoutes();
        config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new JsonViewContractResolver(config.Formatters.JsonFormatter);
    }
