    public class CustomerRoleStore
        : RoleStore<Role, ApplicationDbContext, int, UserRole, RoleClaim>
    {
    	public CustomerRoleStore(
    		ApplicationDbContext context,
    		IdentityErrorDescriber describer = null
    	) : base(
    		context,
    		describer
    	)
    	{ }
    
    	protected override RoleClaim CreateRoleClaim(Role role, Claim claim)
    	{
    		return new RoleClaim
    		{
    			RoleId = role.RoleId,
    			ClaimType = claim.Type,
    			ClaimValue = claim.Value
    		};
    	}
    }
