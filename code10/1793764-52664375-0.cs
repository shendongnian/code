    <!-- language-all: c# -->
        public class MyTestAbpSession : TestAbpSession
        {
            public ClaimsAbpSession ClaimsAbpSession { get; set; }
            public MyTestAbpSession(IMultiTenancyConfig multiTenancy,
                IAmbientScopeProvider<SessionOverride> sessionOverrideScopeProvider,
                ITenantResolver tenantResolver)
                : base(multiTenancy, sessionOverrideScopeProvider, tenantResolver)
            {
            }
            public override long? UserId
            {
                get => base.UserId ?? ClaimsAbpSession.UserId; // Fallback
                set => base.UserId = value;
            }
        }
