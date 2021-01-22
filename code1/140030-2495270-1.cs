    public List<string> GetGroupsFromLogonUserIdentity()
    {
        List<string> groups = new List<string>();
        HttpRequest request = HttpContext.Current.Request;
        if (request.LogonUserIdentity.Groups != null)
        {
            foreach (IdentityReference group in request.LogonUserIdentity.Groups)
            {
                try
                {
                    groups.Add(group.Translate(typeof(NTAccount)).ToString());
                }
                catch (IdentityNotMappedException)
                {
                    // Swallow these exceptions without throwing an error. They are
                    // the result of dead objects in AD which are associated with
                    // user accounts. In this application users may have a group
                    // name associated with their AD profile which cannot be
                    // resolved in the Active Directory.
                }
            }
        }
        return groups;
    }
