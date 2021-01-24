    public class CredentialsAuthorizationServerProvider : OAuthAuthorizationServerProvider 
    {...
       
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
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
                identity.AddClaim(new Claim(ClaimTypes.Role, user.Roles));
                //AuthorizeAttribute.Equals.context
                context.Validated(identity);
            }
