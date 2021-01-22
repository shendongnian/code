    bool hasAccess = false;
    if (SiteMap.CurrentNode == null)
        throw new ApplicationException("Page not present in SiteMap : " + this.Request.Url.AbsolutePath);
    if (SiteMap.CurrentNode.Roles.Count > 0)
    {
        // All roles or no roles
        if (SiteMap.CurrentNode.Roles.Contains("*") == true)
        {
            hasAccess = true;
        }
        else
        {
            for (int index = 0; index < SiteMap.CurrentNode.Roles.Count; index++)
            { 
                string role = SiteMap.CurrentNode.Roles[index].ToString();
                hasAccess = HttpContext.Current.User.IsInRole(role);
                if (hasAccess == true)
                   break;
            }
        }
    }
