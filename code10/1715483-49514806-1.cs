    SessionObject oSessionObject = new SessionObject { Role = Role.Admin };
    Session[“SessionObject”] = oSessionObject;
    
    if (Session[“SessionObject”] != null)
    {
                    vm.SessionObject = ((SessionObject) Session[“SessionObject”]);
    }
