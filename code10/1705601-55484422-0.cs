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
            var stringRoles = user.Roles.Replace(" ", "");//It depends on how you bring them from your DB
            string[] roles = stringRoles.Split(',');//It depends on how you bring them from your DB
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);          
            foreach(var Rol in roles)
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, Rol));
            }
            identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
            identity.AddClaim(new Claim(ClaimTypes.Email, user.Correo));
            identity.AddClaim(new Claim(ClaimTypes.MobilePhone, user.Celular));
            identity.AddClaim(new Claim("FullName", user.FullName));//new ClaimTypes
            identity.AddClaim(new Claim("Empresa", user.Empresa));//new ClaimTypes
            identity.AddClaim(new Claim("ConnectionStringsName", user.ConnectionStringsName));//new ClaimTypes
    //add user information for the client
            var properties = new AuthenticationProperties(new Dictionary<string, string>
            {
                { "userName",user.NombreUsuario },
                { "FullName",user.FullName },
                { "EmpresaName",user.Empresa }
            });
    //end
            var ticket = new AuthenticationTicket(identity, properties);
           context.Validated(ticket);
        }
