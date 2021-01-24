    public static void StartGenerator<T>(T config)
    {
        object generator = null;
        if (config is AGeneratorConfig)
        {
            generator = new AGenerator();
        }
        else if (config is BGeneratorConfig)
        {
            generator = new BGenerator();
        }
        else
        {
            throw new NotImplementedException();
        }
        ((Generator<T>)generator).Start(config);
    }
