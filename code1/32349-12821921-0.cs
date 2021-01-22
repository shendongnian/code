    IList<string> getMembers(string domainName, string groupName)
        {
            PrincipalContext ctx = new PrincipalContext(ContextType.Domain, domainName);
            GroupPrincipal grp = GroupPrincipal.FindByIdentity(ctx, IdentityType.Name, groupName);
            
            if (grp == null) { 
                throw new ApplicationException("We did not find that group in that domain, perhaps the group resides in a different domain?");
            }
    
            IList<string> members = new List<String>();
    
            foreach (Principal p in grp.GetMembers(true))
            {
                members.Add(p.Name); //You can add more attributes, samaccountname, UPN, DN, object type, etc... 
            }
            grp.Dispose();
            ctx.Dispose();
            
            return members;
        }
