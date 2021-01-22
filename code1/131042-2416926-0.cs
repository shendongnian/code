    public class CustomUsernameSecurityTokenAuthenticator : UserNameSecurityTokenAuthenticator
    {
    	protected override bool CanValidateTokenCore(System.IdentityModel.Tokens.SecurityToken token)
    	{
    		return (token is UserNameSecurityToken);
    	}
    
    	protected override ReadOnlyCollection<IAuthorizationPolicy> ValidateTokenCore(SecurityToken token)
    	{
    		var authorizationPolicies = new List<IAuthorizationPolicy>();
    
    		try
    		{
    			var userNameToken = token as UserNameSecurityToken;
    			new CustomUserNameValidator().Validate(userNameToken.UserName, userNameToken.Password);
    			
    			var claims = new DefaultClaimSet(ClaimSet.System, new Claim(ClaimTypes.Name, userNameToken.UserName, Rights.PossessProperty));
    			
    			authorizationPolicies.Add(new CustomAuthorizationPolicy(claims));
    		}
    		catch (Exception)
    		{
    			authorizationPolicies.Add(new InvalidAuthorizationPolicy());
    			throw;
    		}
    		return authorizationPolicies.AsReadOnly();
       	}
    }
