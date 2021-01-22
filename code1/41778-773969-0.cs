    Microsoft.Web.Administration.ServerManager manager = new Microsoft.Web.Administration.ServerManager();
    Site defaultSite = manager.Sites["Default Web Site"];
    // defaultSite.Applications will give you the list of 'this' web site reference and all
    // virtual directories inside it -- 0 index is web site itself.
    Microsoft.Web.Administration.Application oVDir = defaultSite.Applications["/myApp"];            
    oVDir.ApplicationPoolName = "NewApplicationPool";
    manager.CommitChanges();
