     public bool  AddUserToGroup(string userName, string groupName)
    
            {
    
                bool done = false;
    
                GroupPrincipal group = GroupPrincipal.FindByIdentity(context, groupName);
    
                if (group == null)
    
                {
    
                    group = new GroupPrincipal(context, groupName);
    
                }
    
                UserPrincipal user = UserPrincipal.FindByIdentity(context, userName);
    
                if (user != null & group != null)
    
                {
    
                    group.Members.Add(user);
    
                    group.Save();
    
                    done = (user.IsMemberOf(group));
    
                }
    
                return done;
    
            }
