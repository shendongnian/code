    using(PrincipalContext ctx = new PrincipalContext(ContextType.Domain))
    {
        using(p = Principal.FindByIdentity(ctx, "yourUserName"))
        {
            var groups = p.GetGroups();
    
            using (groups)
            {
                foreach (Principal group in groups)
                {
                    Console.WriteLine(group.SamAccountName + "-" + group.DisplayName);
                }
            }
        }
    }
