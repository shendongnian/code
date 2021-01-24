    public class DbPolicyProvider : IAuthorizationPolicyProvider
    {
        private readonly IServiceProvider _serviceProvider;
        public DbPolicyProvider(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public async Task<AuthorizationPolicy> GetDefaultPolicyAsync()
        {
            return await GetPolicyAsync("DbPolicy");
        }
        public Task<AuthorizationPolicy> GetPolicyAsync(string policyName)
        {
            using (var db = _serviceProvider.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>())
            {
                var policys = db.Policys.Where(p => p.Name == policyName).ToList();
                var build = new AuthorizationPolicyBuilder();
                foreach (var policy in policys)
                {
                    build.RequireClaim(policyName, policy.Config);
                }
                return Task.FromResult(build.Build());
            }
        }
    }
