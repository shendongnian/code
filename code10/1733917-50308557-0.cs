    public class MySettingStore : SettingStore
    {
        public MySettingStore(
            IRepository<Setting, long> settingRepository,
            IUnitOfWorkManager unitOfWorkManager)
            : base(settingRepository, unitOfWorkManager)
        {
        }
        public override Task<SettingInfo> GetSettingOrNullAsync(int? tenantId, long? userId, string name)
        {
            return base.GetSettingOrNullAsync(tenantId, userId, name)
                ?? DefaultConfigSettingStore.Instance.GetSettingOrNullAsync(tenantId, userId, name);
        }
    }
