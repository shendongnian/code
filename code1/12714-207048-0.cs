    foreach (SPRoleAssignment spAssignment in workspace.RoleAssignments)
    {
        if (spAssignment.Member.Name == shortName)
        {
            workspace.RoleAssignments.Remove(spAssignment);
            break;
        }
    }
