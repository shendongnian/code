     public  void StartGenerator<T>(T config)
        {
            var generator = GetGenerator<T>();
            generator.Start(config);
        }
        public static void Main()
        {
            var gen = new GeneratorClient();
            gen.CreateDicionary();
            gen.StartGenerator<AGeneratorConfig>(new AGeneratorConfig());
        }
