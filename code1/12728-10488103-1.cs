    foreach (SPRoleAssignment spAssignment in workspace.RoleAssignments.ToList())
    {
        if (spAssignment.Member.Name == shortName)
        {
            workspace.RoleAssignments.Remove(spAssignment);
        }
    }
