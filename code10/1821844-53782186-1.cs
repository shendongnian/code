    public class MyUserStore : IUserStore<User>, IUserRoleStore<User>, IQueryableUserStore<User>
    {
        private Context _db;
        private RoleManager<Role> _roleManager;
       ...
        public async Task<User> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            // bridge your ClaimsPrincipal to your DB users
            var user = db.Users.SingleOrDefault(_ => _.Email.ToUpper() == normalizedUserName);
            return await Task.FromResult(user);
        }
       ...
        public async Task<bool> IsInRoleAsync(User user, string roleName, CancellationToken cancellationToken)
        {
            if (roleName == null)
                return true;
            // your custom logic to check role in DB
            var result = user.Roles.Any(_ => _.RoleName == roleName);
            return await Task.FromResult(result);
        }
