        public T GetSettingsWithDictionary<T>() where T:new()
        {
            IConfigurationRoot _configurationRoot = new ConfigurationBuilder()
            .AddXmlFile($"{Assembly.GetExecutingAssembly().Location}.config", false, true).Build();
            var instance = new T();
            foreach (var property in typeof(T).GetProperties())
            {
                if (property.PropertyType == typeof(Dictionary<string, string>))
                {
                    property.SetValue(instance, _configurationRoot.GetSection(typeof(T).Name).Get<Dictionary<string, string>>());
                    break;
                }
            }
            return instance;
        }
