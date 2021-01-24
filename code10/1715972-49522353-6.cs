    class Provider : IProvider
    {
        private readonly ProviderSetting providerSetting;
        public Provider(ProviderSettingFactory factory)
        {
            providerSetting = factory("someClientId", "someAppKey");
        }
    }
