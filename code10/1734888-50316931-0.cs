     public override async Task<MyUser> FindByIdAsync(string userId)
            {
                var user = await base.FindByIdAsync(userId);
                var roleStore = this.Store as IUserRoleStore<MyUser, string>;
                user.RoleNames = await roleStore.GetRolesAsync(user);
                return user;
            }
