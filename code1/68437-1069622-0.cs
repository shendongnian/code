            // get list item
            SPListItem item = <your list item>;
            if (!item.HasUniqueRoleAssignments)
            {
                item.BreakRoleInheritance(true);
            }
            // get principal
            SPPrincipal principal = <principal to grant permissions to>;
            // get role definition
            SPRoleDefinition rd = <role that contains the permissions to be granted to the principal>;
            // create role assignment
            SPRoleAssignment ra = new SPRoleAssignment(principal);
            ra.RoleDefinitionBindings.Add(rd);
            item.RoleAssignments.Add(ra);
