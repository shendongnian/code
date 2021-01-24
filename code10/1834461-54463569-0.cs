            try
            {
                //GroupPrincipal group = GroupPrincipal.FindByIdentity(ctx, groupName);
                //group.Members.Add(ctx, IdentityType.UserPrincipalName, userId);
                //group.Save();
                GroupPrincipal groupPrincipal = GroupPrincipal.FindByIdentity(ctx, groupName);
                if (groupPrincipal != null) {
                    DirectoryEntry entry = (DirectoryEntry)groupPrincipal.GetUnderlyingObject();
                    entry.Invoke("Add", new object[] { userId.Path.ToString() });
                    userId.CommitChanges();
                }
                else {
                    return true;
                }
                
                return true;
            }
            catch
            {
                return false;
            }
        }
