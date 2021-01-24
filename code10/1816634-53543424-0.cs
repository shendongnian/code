    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CheckAntiForgeryTokenValidation : FilterAttribute, IAuthorizationFilter
    {
        private readonly IIdentityConfigManager _configManager = CastleClassFactory.Instance.Resolve<IIdentityConfigManager>();
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            var configValue = System.Configuration.ConfigurationManager.AppSettings["IsAntiForgeryTokenValidationEnabled"];
            //Do not validate the token if the config value is not provided or it's value is not "true".
            if(string.IsNullOrEmpty(configValue) || configValue != "true")
            {
                return;
            }
            // Validate the token if the configuration value is "true".
            else
            {
                new ValidateAntiForgeryTokenAttribute().OnAuthorization(filterContext);
            }
        }
    }
