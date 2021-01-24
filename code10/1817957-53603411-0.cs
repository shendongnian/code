    public class CustomPolicyProvider : DefaultAuthorizationPolicyProvider
	{
		private const string PermissionPolicyPrefix = "HasPermission";
		
		public CustomPolicyProvider(IOptions<AuthorizationOptions> options) : base(options)
		{
		}
		
		public override async Task<AuthorizationPolicy> GetPolicyAsync(string policyName)
		{
			var policy = await base.GetPolicyAsync(policyName);
			if (policy != null) return policy;
			if (policyName.StartsWith(PermissionPolicyPrefix, StringComparison.OrdinalIgnoreCase))
			{
				var permission = policyName.Substring(PermissionPolicyPrefix.Length);
				
				return new AuthorizationPolicyBuilder()
					.AddRequirements(new HasPermissionRequirement(permission))
					.Build();
			}
			
			return null;
		}
	}
