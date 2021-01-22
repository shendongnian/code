    PrincipalContext ctx = new PrincipalContext(ContextType.Domain, "DomainName"); 
    GroupPrincipal grp = GroupPrincipal.FindByIdentity(ctx, IdentityType.Name, "TestGroup"); 
    
    ArrayList users = new ArrayList();
    ArrayList groups = new ArrayList(); 
     
    if (grp != null) 
    { 
        foreach (Principal p in grp.GetMembers(false)) //set to false
        {
            if (p.StructuralObjectClass == "user")
                users.Add(p.Name);
            else if (p.StructuralObjectClass == "group")
                groups.Add(p.Name);
        }
    }    
    grp.Dispose(); 
    ctx.Dispose();
