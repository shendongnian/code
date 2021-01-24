        //
        // Summary:
        //     Removes the specified user from the named role.
        //
        // Parameters:
        //   user:
        //     The user to remove from the named role.
        //
        //   role:
        //     The name of the role to remove the user from.
        //
        // Returns:
        //     The System.Threading.Tasks.Task that represents the asynchronous operation, containing
        //     the Microsoft.AspNetCore.Identity.IdentityResult of the operation.
        [AsyncStateMachine(typeof(UserManager<>.<RemoveFromRoleAsync>d__106))]
        public virtual Task<IdentityResult> RemoveFromRoleAsync(TUser user, string role);
