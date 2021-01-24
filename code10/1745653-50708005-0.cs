    //This is a method I use in a WCF web service I created
    //userName is the domain name of the user
    //groupName is the AD group 
    public bool IsMemberOfGroup(string groupName, string userName)
            {
                try
                {
                    PrincipalContext context = new PrincipalContext(ContextType.Domain);
    
                    UserPrincipal user = UserPrincipal.FindByIdentity(context, userName);
    
                    GroupPrincipal group = GroupPrincipal.FindByIdentity(context, groupName);
    
                    if (group == null)
                        return false;
    
                    if (user != null)
                        return group.Members.Contains(user);
                }
                catch (System.Exception ex)
                {
                    //Log exception
                }
    
    
                return false;
            }
