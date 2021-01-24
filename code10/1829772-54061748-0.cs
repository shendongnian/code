    protected override void Application_BeginRequest(object sender, EventArgs e)
    {
        base.Application_BeginRequest(sender, e);
        var iocResolver = Ks.Dependency.IocManager.Instance.Resolve<IIocResolver>();
        var scope = iocResolver .CreateScope());
        var service = scope.Resolve<Service.MobileUser.IMobileUserService>();
    }
        
