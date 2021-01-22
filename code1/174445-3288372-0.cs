    public static class MyServiceFactory
    {
        public static IMyService GetServiceForCurrentUser()
        {
            var highestRoleForUser = GetHighestRoleForUser();
            Container.Resolve<IMyService>(highestRoleForUser);
        }
        private static string GetHighestRoleForUser()
        {
            var roles = Roles.GetRolesForUser().ToList();
            roles.Sort();
            return roles.Last();
        }
    }
