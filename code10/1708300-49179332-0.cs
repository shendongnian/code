    private static List<Principal> GetPrincipalList (string strPropertyValue, string strDomainController)
            {
                List<Principal> listPrincipal = null;
                Principal principal = null;
                GroupPrincipal groupPrincipal = null;
                UserPrincipal userPrincipal = null;
                ComputerPrincipal computerPrincipal = null;
                PrincipalSearchResult<Principal> listPrincipalSearchResult = null; // Groups
                PrincipalContext principalContext = null;
                ContextType contextType;
                IdentityType identityType;
    
                try
                {
                    // Setup a UserPrincipal list.
                    listPrincipal = new List<Principal>();
    
                    // Set the contextType to Domain because we are going through the AD directory store.
                    contextType = ContextType.Domain;
    
                    // Setup a domain context.
                    principalContext = new PrincipalContext(contextType, strDomainController);
    
                    // Setup the IdentityType. This is required, otherwise you will get a MultipleMatchesException error that says "Multiple principals contain a matching Identity."
                    // This happens when you have two objects that AD thinks match whatever you're passing to UserPrincipal.FindByIdentity(principalContextDomain, strPropertyValue)
                    // Use IdentityType.Guid because GUID is unique and never changes for a given object.                   
                    identityType = IdentityType.Guid;
    
                    // Find user.
                    principal = Principal.FindByIdentity(principalContext, identityType, strPropertyValue);
                    groupPrincipal = GroupPrincipal.FindByIdentity(principalContext, identityType, strPropertyValue);
                    userPrincipal = UserPrincipal.FindByIdentity(principalContext, identityType, strPropertyValue);
                    computerPrincipal = ComputerPrincipal.FindByIdentity(principalContext, identityType, strPropertyValue);
                    
                    // Return the listPrincipal list.
                    return listPrincipal;
                }
                finally
                {
                    // Cleanup objects.
                    listPrincipal = null;
                    listPrincipalSearchResult = null;
                    principalContext = null;
                    groupPrincipal = null;
                    userPrincipal = null;
                    computerPrincipal = null;
                }
            }
