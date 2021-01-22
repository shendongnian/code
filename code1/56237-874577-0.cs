    protected void Page_Load(object sender, EventArgs e)
    {
            XmlDocument permissionsDoc = null;
            
            if (Cache["Permissions"] == null)
            {
                string path = Server.MapPath("~/XML/Permissions.xml");
                permissionsDoc = new XmlDocument();
                permissionsDoc.Load(Server.MapPath("~/XML/Permissions.xml"));
                Cache.Add("Permissions", permissionsDoc,
                                new CacheDependency(Server.MapPath("~/XML/Permissions.xml")),
                               Cache.NoAbsoluteExpiration, Cache.NoSlidingExpiration,
                        CacheItemPriority.Default, new CacheItemRemovedCallback(ReloadPermissionsCallBack));
            }
            else
            {
                permissionsDoc = (XmlDocument)Cache["Permissions"];
            }
    }
    
    private void ReloadPermissionsCallBack(string key, object value, CacheItemRemovedReason reason)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Server.MapPath("~/XML/Permissions.xml"));
            Cache.Insert("Permissions", doc ,
                                new CacheDependency(Server.MapPath("~/XML/Permissions.xml")),
                               Cache.NoAbsoluteExpiration, Cache.NoSlidingExpiration,
                        CacheItemPriority.Default, new CacheItemRemovedCallback(ReloadPermissionsCallBack));
        }
