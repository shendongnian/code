    private bool IsMember()
        {
            bool isMember;
            SPSite site = new SPSite(SiteURL);
            SPWeb web = site.OpenWeb();
            isMember = web.IsCurrentUserMemberOfGroup(web.Groups["GroupName"].ID);
            web.Close();
            site.Close();
            return isMember;
        }
