                GroupPrincipal group = GroupPrincipal.FindByIdentity(principalContext, "groupName");
                UserPrincipal user = UserPrincipal.FindByIdentity(principalContext, "userName");
    
                bool isUserAdded = false;
    
    
                if (user != null & group != null)
                {
                    if (user.IsMemberOf(group))
                    {
                        //Do Code
                    }
                    else
                    {
                        group.Members.Add(user);
                        group.Save();
                        isUserAdded = user.IsMemberOf(group);
                    }
                }
    
                if (isUserAdded)
                {
                    //Do Code
                }
