    public static UserPrincipal GetUserPrincipal(String userName)
            {
                UserPrincipal up = null;
    
                PrincipalContext context = new PrincipalContext(ContextType.Domain);
                up = UserPrincipal.FindByIdentity(context, userName);
    
                if (up == null)
                {
                    context = new PrincipalContext(ContextType.Machine);
                    up = UserPrincipal.FindByIdentity(context, userName);
                }
    
                if(up == null)
                    throw new Exception("Unable to get user from Domain or Machine context.");
    
                return up;
            }
