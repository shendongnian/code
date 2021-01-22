    context.Load(context.GetUserRolesQuery(), loadOp =>
    {
        IEnumerable<UserRole> roles = loadOp.Entities;
        MessageBox.Show("Permissions loaded: " + roles.First().UserPermissionMembers.Count.ToString());
    }
