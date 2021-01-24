    public override string[] GetRolesForUser(string nickname)
        {
            using(var userService = ResolveUserService())
            {
                return new string[] {userService.Value.GetRoleForUser(nickname) };
            }
        }
