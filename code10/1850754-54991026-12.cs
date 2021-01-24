    public class CredentialsAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
    	// ...
    
    	public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
    	{
    		context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
    		LoginModel model = new LoginModel();
    		
    		//validate user credentials and obtain user roles (return List Roles) 
    		//validar las credenciales de usuario y obtener roles de usuario
    		var user = model.User = _serviceUsuario.ObtenerUsuario(context.UserName, context.Password);
    		if (user == null)
    		{
    			context.SetError("invalid_grant", "El nombre de usuario o la contraseña no son correctos.cod 01");
    			return;
    		}
    
    		var stringRoles = user.Roles.Replace(" ", "");
    		string[] roles = stringRoles.Split(',');
    		var identity = new ClaimsIdentity(context.Options.AuthenticationType);
    		
    		foreach (var Rol in roles)
    		{
    			identity.AddClaim(new Claim(ClaimTypes.Role, Rol));
    		}
    		
    		identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
    
    		AuthenticationProperties properties = CreateProperties(context.UserName);
    		var ticket = new AuthenticationTicket(identity, properties);
    
    		context.Validated(ticket);
    	}
    }
