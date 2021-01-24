            Boolean LBReturn = false;
            // set up domain context
            PrincipalContext ctx = new PrincipalContext(ContextType.Domain, "Put your domain name here. Right click on My computer and go to properties to see the domain name");
            // find a user
            UserPrincipal user = UserPrincipal.FindByIdentity(ctx, LSUserName);
            // find the group in question
            GroupPrincipal group = GroupPrincipal.FindByIdentity(ctx, LSGroupName);
            if (user != null)
            {
                // check if user is member of that group
                if (user.IsMemberOf(group))
                {
                    LBReturn = true;
                }
                else
                {
                    var LSAllMembers = group.GetMembers(true);
                    foreach(var LSName in LSAllMembers)
                    {
                        string LSGPUserName = LSName.SamAccountName.ToUpper();
                        if (LSGPUserName == PSUserName.ToUpper())
                        {
                            LBReturn = true;
                        }
                    }
                }
            }
            return LBReturn;
        }
