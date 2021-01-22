           using (PrincipalContext context = XXX)
            {   //get the group
                    using (GroupPrincipal groupPrincipal =
                            GroupPrincipal.FindByIdentity(context,IdentityType.SamAccountName, group))
                    {
                        if (groupPrincipal != null)
                        {
                            //get the user
                            using (UserPrincipal userPrincipal =
                      UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, userName))
                            {
                                if (userPrincipal != null)
                                {
                                    returnValue = userPrincipal.IsMemberOf(groupPrincipal);
                                }
                            }
                        }
                    }
            }
          
