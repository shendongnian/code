        public class SecuritySettingService : ISecuritySettingService
        {
            private readonly ISecuritySettingRepository _securitySettingRepository;
            private readonly IdentityOptions _identityOptions;
            public SecuritySettingService(ISecuritySettingRepository securitySettingRepository
                , IOptions<IdentityOptions> identityOptions)
            {
                _securitySettingRepository = securitySettingRepository;
                _identityOptions = identityOptions.Value;
            }
            public LockoutOption GetSecuritySetting()
            {
                return _securitySettingRepository.GetSecuritySetting();
            }
            public LockoutOption UpdateSecuritySetting(LockoutOption lockoutOption)
            {
                var option = _securitySettingRepository.UpdateSecuritySetting(lockoutOption);
                //update identity options
                _identityOptions.Lockout.MaxFailedAccessAttempts = option.MaxFailedAccessAttempts;
                return option;
            }
        }
