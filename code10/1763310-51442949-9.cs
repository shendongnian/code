                    GroupPrincipal group = GroupPrincipal.FindByIdentity(principalContext, "groupName");
                    UserPrincipal user = UserPrincipal.FindByIdentity(principalContext, "userName");
    
                    bool isUserRemoved = false;
    
    
                    if (user != null & group != null)
                    {
                        if (user.IsMemberOf(group))
                        {
                            group.Members.Remove(user);
                            group.Save();
                            isUserRemoved = user.IsMemberOf(group);
                        }
                        else
                        {
                            //Do Code
                            
                        }
                    }
    
                    if (!isUserRemoved)
                    {
                        //Do Code
                    }
