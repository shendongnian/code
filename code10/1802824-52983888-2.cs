        public class LEMClaimPolicyProvider : IAuthorizationPolicyProvider
        {
        const string POLICY_PREFIX = "LEMClaim";
        const string POLICY_PREFIX_ELocation = "LEMClaim.ELocation";
        const string POLICY_PREFIX_EEntity = "LEMClaim.EEntity";
        public DefaultAuthorizationPolicyProvider FallbackPolicyProvider { get; }
        public LEMClaimPolicyProvider(IOptions<AuthorizationOptions> options)
        {
            FallbackPolicyProvider = new DefaultAuthorizationPolicyProvider(options);
        }
        public Task<AuthorizationPolicy> GetDefaultPolicyAsync() => FallbackPolicyProvider.GetDefaultPolicyAsync();
        public Task<AuthorizationPolicy> GetPolicyAsync(string policyName)
        {
            if (!policyName.StartsWith(POLICY_PREFIX, StringComparison.OrdinalIgnoreCase))
                return FallbackPolicyProvider.GetPolicyAsync(policyName);
            var val = policyName.Split(";");
            //get locations
            int[] ia1 = val.FirstOrDefault(k => k.StartsWith(POLICY_PREFIX_ELocation, StringComparison.OrdinalIgnoreCase))
                           .Substring(POLICY_PREFIX_ELocation.Length)
                           .Split(',').Select(n => Convert.ToInt32(n)).ToArray();
            ELocation[] locations = (ELocation[])(object)ia1;
            int[] ia2 = val.FirstOrDefault(k => k.StartsWith(POLICY_PREFIX_EEntity, StringComparison.OrdinalIgnoreCase))
                           ?.Substring(POLICY_PREFIX_EEntity.Length)
                           ?.Split(',').Select(n => Convert.ToInt32(n)).ToArray();
            EEntity[] entitys = (EEntity[])(object)ia2;
            var policy = new AuthorizationPolicyBuilder();
            policy.AddRequirements(new LEMClaimRequirement(locations, entitys));
            return Task.FromResult(policy.Build());
        }
        }
