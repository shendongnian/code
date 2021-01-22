    foreach (SPRoleAssignment spAssignment in workspace.RoleAssignments)
                            {
                                if (spAssignment.Member.Name != shortName) continue;
                                workspace.RoleAssignments.Remove((SPPrincipal)spAssignment.Member);
                                break;
                            }
