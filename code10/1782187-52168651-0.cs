    public enum ValueType
    {
        ReturnedConfigured,
        NotConfiguredReturnedDefault,
        InvalidConfigurationReturnedDefault
    }
    public interface IConfigurationProvider
    {
        (T result, ValueType resultType) GetSetting<T>(string serviceName, string settingKey, T defaultValue);
    }
    public interface IService
    {
        int Calculate(int userId, IConfigurationProvider configurationProvider);
    }
