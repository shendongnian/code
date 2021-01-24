    internal class CustomeSqlMembershipProvider : SqlMembershipProvider
    {
        public CustomeSqlMembershipProvider(IOptions<MembershipSettings> settings)
        {
            InitializeProvider(settings.Value);
        }
        protected virtual void InitializeProvider(MembershipSettings settings)
        {
            base.Initialize(settings.Provider.Name, PrepareSettings(settings.Provider));
        }
        private NameValueCollection PrepareSettings(Provider provider) => new NameValueCollection
        {
            //you can use reflection to do that as well
            { nameof(provider.ApplicationName), provider.ApplicationName},
            {nameof(provider.ConnectionStringName), provider.ConnectionStringName}
            
            //...
            //etc
        };
    }
