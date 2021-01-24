    var employees = (from bb in _appContext.Users
                join roleIds in _appContext.UserRoles on bb.Id equals roleIds.UserId
                join role in _appContext.Roles on roleIds.RoleId equals role.Id into roles
                orderby bb.LastName, bb.FirstName
                where roles !=null && roles.Any(e => e.Name == Permissions.RoleNames.Administrator || e.Name == Permissions.RoleNames.Employee)
                select ManageUserModel.FromInfo(bb, roles)).ToList();
    public static ManageUserModel FromInfo(ApplicationUser info, IEnumerable<UserRole> roles)
        {
            var ret= FromInfo(info);
            ret.Roles = roles.Select(e => new SimpleEntityString() {Id=e.Id, Text=e.Name}).ToList();
            return ret;
        }
