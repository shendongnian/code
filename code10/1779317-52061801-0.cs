    public virtual string GetSid()
        {
            using (HostingEnvironment.Impersonate())
            {
                PrincipalContext ctx = new PrincipalContext(ContextType.Domain);
                UserPrincipal user = UserPrincipal.FindByIdentity(ctx, User.Identity.Name);
                var sid = user.Sid;
                return sid.ToString();
            }
        }
