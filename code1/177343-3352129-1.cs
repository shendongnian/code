    if (SessionUser.Instance().SiteId != siteId)
    {
        lock(somePrivateStaticObject)
        {
            if (SessionUser.Instance().SiteId != siteId)
            {
                SessionUser.Instance().SiteId = siteId;
            }
        }
    }
