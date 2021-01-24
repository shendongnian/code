    public class NonUserAuthorizationHelper : AuthorizationHelper
    {
        private readonly IAuthorizationConfiguration _authConfiguration
        public NonUserAuthorizationHelper(IFeatureChecker featureChecker, IAuthorizationConfiguration authConfiguration)
            : base(featureChecker, authConfiguration)
        {
            _authConfiguration = authConfiguration;
        }
    
        public override async Task AuthorizeAsync(IEnumerable<IAbpAuthorizeAttribute> authorizeAttributes)
        {
            if (!_authConfiguration.IsEnabled)
            {
                return;
            }
            // if (!AbpSession.UserId.HasValue)
            // {
            //     throw new AbpAuthorizationException(
            //         LocalizationManager.GetString(AbpConsts.LocalizationSourceName, "CurrentUserDidNotLoginToTheApplication")
            //     );
            // }
            foreach (var authorizeAttribute in authorizeAttributes)
            {
                await PermissionChecker.AuthorizeAsync(authorizeAttribute.RequireAllPermissions, authorizeAttribute.Permissions);
            }
        }
    }
