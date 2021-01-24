    public class FakeConfigurationProvider : IConfigurationProvider
    {
        public (T result, ValueType resultType) GetSetting<T>(string serviceName, string settingKey, T defaultValue)
        {
            switch (settingKey)
            {
                case "Min":
                    {
                        return (result: (T)Convert.ChangeType(1, typeof(T)), resultType: ValueType.ReturnedConfigured);
                    }
                case "Max":
                    {
                        return (result: (T)Convert.ChangeType(42, typeof(T)), resultType: ValueType.ReturnedConfigured);
                    }
                case "Filter":
                    {
                        return (result: (T)Convert.ChangeType("Hello World", typeof(T)), resultType: ValueType.ReturnedConfigured);
                    }
                default:
                    {
                        return (result: defaultValue, resultType: ValueType.NotConfiguredReturnedDefault);
                    }
            }
        }
    }
