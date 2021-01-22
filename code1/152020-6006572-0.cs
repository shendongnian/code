	public void Demand()
	{
		var principal = Thread.CurrentPrincipal;
		if(principal == null || principal.Identity.IsAuthenticated == false)
		{
			throw new SecurityException("Unable to get IPrincipal.");
		}
		if(principal.Identity.IsAuthenticated == false)
		{
			throw new SecurityException("You must be authenticated.");
		}   
         #warning this should be moved to an aop attribute that is injected by a ioc container.
		using (var connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["......."].ConnectionString))
		{
			connection.Open();
			using(var command = new SqlCommand(
			@"
				SELECT COUNT(t.name) FROM
				(
					SELECT p.name, u.UserName FROM 
						aspnet_Users as u
						INNER JOIN [User_Permission] as up
							ON up.user_id = u.UserId
						INNER JOIN Permission as p
							ON p.id = up.permission_id
					UNION
					SELECT p2.name, u2.UserName FROM 
						aspnet_Users as u2
						INNER JOIN aspnet_UsersInRoles as uir
							ON uir.UserId = u2.UserId
						INNER JOIN aspnet_Roles as r
							ON r.RoleId = uir.RoleId
						INNER JOIN Role_Permission as rp
							ON rp.role_id = r.RoleId
						INNER JOIN Permission as p2
							ON p2.id = rp.permission_id
				) as t
				WHERE t.UserName = @username AND t.name = @haspermission
			", connection))
			{
				command.Parameters.Add("@username", SqlDbType.VarChar).Value = Thread.CurrentPrincipal.Identity.Name;
				command.Parameters.Add("@haspermission", SqlDbType.VarChar).Value = _permissionRequested;
				if( Convert.ToInt32(command.ExecuteScalar()) <=0)
				{
					throw new SecurityException(String.Format("User '{0}' is not assigned permission '{1}'.", principal.Identity.Name, _permissionRequested));
				}
			}
		}
	}
