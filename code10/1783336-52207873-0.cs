    kernel.Bind<UserCredentials>().ToMethod(CreateUserCredentials);
    private static UserCredentials CreateUserCredentials(IContext arg)
        {
            var identity = HttpContext.Current.User as ClaimsPrincipal;
            int userId = identity.Identity.GetUserId();
            string clientCode = identity.Identity.GetClientCode();
            var userManagementService = kernel.Get<IUserManagementService>();
            if (userId != 0)
            {
                var permisssions = userManagementService.GetUserPermissions(userId, userType, clientCode);
            }
            return new UserCredentials()
            {
                ClientCode = clientCode,
                UserId = userId,
                Permissions = userManagementService.GetUserPermissions(userId, clientCode)
            };
        }
