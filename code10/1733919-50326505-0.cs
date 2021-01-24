       public class MySettingStore : ISettingStore
        {
            public Task CreateAsync(SettingInfo setting)
            {
                throw new NotImplementedException();
            }
    
            public Task DeleteAsync(SettingInfo setting)
            {
                throw new NotImplementedException();
            }
    
            public Task<List<SettingInfo>> GetAllListAsync(int? tenantId, long? userId)
            {
                var result = new List<SettingInfo>();
                var keys = ConfigurationManager.AppSettings.AllKeys;
    
                foreach (var key in keys)
                {
                    result.Add(new SettingInfo(null, null, key, ConfigurationManager.AppSettings[key]));
                }
    
                return Task.FromResult(result);
            }
    
            public Task<SettingInfo> GetSettingOrNullAsync(int? tenantId, long? userId, string name)
            {
                var value = ConfigurationManager.AppSettings[name];
    
                if (value == null)
                {
                    return Task.FromResult<SettingInfo>(null);
                }
    
                return Task.FromResult(new SettingInfo(tenantId, userId, name, value));
            }
    
            public Task UpdateAsync(SettingInfo setting)
            {
                throw new NotImplementedException();
            }
        }
