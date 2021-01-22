    // Assuming you already have SPWeb and SPList objects
    ...
    SPRoleAssignment roleAssignment = new SPRoleAssignment("dom\\user", "user@dom", "user", "some notes");
    SPRoleDefinition roleDefinition = web.RoleDefinitions.GetByType(SPRoleType.Contributor);
    roleAssignment.RoleDefinitionBindings.Add(roleDefinition);
    if (!myList.HasUniqueRoleAssignments)
    {
        myList.BreakRoleInheritance(true); // Ensure we don't inherit permissions from parent
    } 
    myList.RoleAssignments.Add(roleAssignment);
    myList.Update();
